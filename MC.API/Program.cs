using MC.API.Extensions;
using MC.API.Middlewares;
using MC.API.Resources;
using MC.Application;
using MC.Application.Contracts.Identity;
using MC.Application.Contracts.Persistence.Common;
using MC.Application.Settings;
using MC.Domain.Entity.Identity;
using MC.Infrastructure;
using MC.Infrastructure.Identity;
using MC.Persistence;
using MC.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QuestPDF.Infrastructure;
using Serilog;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// ---------- Serilog ----------
//builder.Host.UseSerilog((ctx, lc) =>
//    lc.ReadFrom.Configuration(ctx.Configuration).WriteTo.Console());
builder.Host.UseSerilog((ctx, lc) =>
{
    lc.ReadFrom.Configuration(ctx.Configuration)
      .Enrich.FromLogContext()
      .WriteTo.Console() // still see logs in console/VS Output
      .WriteTo.File(
          path: "Logs/app-log-.txt",
          rollingInterval: RollingInterval.Day,
          retainedFileCountLimit: 30, // keep last 30 days
          shared: true);
});

// ---------- Load Configuration ----------
var configuration = builder.Configuration;
configuration
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

// ---------- Strongly typed settings ----------
builder.Services.Configure<ApplicationConfigSettings>(configuration.GetSection("ApplicationConfig"));
builder.Services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
builder.Services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

// Bind AppSettings instance to use in static helper
var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();

// Safely access appSettings and its properties to avoid CS8602
if (appSettings?.TimeZone != null && appSettings.DateTimeFormats?.Default != null)
{
    MC.Persistence.Helper.DateHelper.Configure(appSettings.TimeZone, appSettings.DateTimeFormats.Default);
}
else
{
    throw new InvalidOperationException("AppSettings or its required properties (TimeZone, DateTimeFormats.Default) are not configured properly.");
}

// Identity Configuration
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDatabaseContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30); // Lockout period
    options.Lockout.MaxFailedAccessAttempts = 5; // Lock after 5 attempts
    options.Lockout.AllowedForNewUsers = true; // Enable lockout for all users
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.User.RequireUniqueEmail = true;
});

//to access environment
builder.Services.AddScoped<IAppEnvironment>(sp =>
{
    var env = sp.GetRequiredService<IWebHostEnvironment>();
    return new AppEnvironment(env);
});
QuestPDF.Settings.License = LicenseType.Community;
builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromHours(24); // Link valid for 24h
});

// ---------- Controllers ----------
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// ---------- CORS ----------
var appConfig = configuration.GetSection("ApplicationConfig").Get<ApplicationConfigSettings>() ?? new ApplicationConfigSettings { CorsOrigins = new List<string>() };
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy
            .WithOrigins(appConfig.CorsOrigins.ToArray())
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", policy =>
//    {
//        policy.AllowAnyOrigin() // Remove this in production if using credentials
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});

// ---------- JWT Authentication ----------
// JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
if (jwtSettings == null || string.IsNullOrWhiteSpace(jwtSettings.Key) ||
    string.IsNullOrWhiteSpace(jwtSettings.Issuer) || string.IsNullOrWhiteSpace(jwtSettings.Audience))
{
    throw new InvalidOperationException("JWT settings are not configured properly.");
}

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true; // Production only
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
        ClockSkew = TimeSpan.Zero,
        NameClaimType = "uid",
        RoleClaimType = ClaimTypes.Role
    };

    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = async ctx =>
        {
            var identity = ctx.Principal.Identity as ClaimsIdentity;
            if (identity != null)
            {
                // Replace NameIdentifier with correct user ID if needed
                var existing = identity.FindFirst(ClaimTypes.NameIdentifier);
                if (existing != null) identity.RemoveClaim(existing);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, ctx.Principal.FindFirst("uid")?.Value ?? string.Empty));
            }
            await Task.CompletedTask;
        },
        OnAuthenticationFailed = ctx =>
        {
            Console.WriteLine($"JWT authentication failed: {ctx.Exception.Message}");
            return Task.CompletedTask;
        }
    };
});
//builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

//    if (jwtSettings == null)
//    {
//        throw new InvalidOperationException("JwtSettings configuration section is missing or invalid.");
//    }

//    if (string.IsNullOrWhiteSpace(jwtSettings.Issuer) ||
//    string.IsNullOrWhiteSpace(jwtSettings.Audience) ||
//    string.IsNullOrWhiteSpace(jwtSettings.Key))
//    {
//        throw new InvalidOperationException("JwtSettings is missing required values: Issuer, Audience, or Key.");
//    }

//    options.RequireHttpsMetadata = true; // Enable in production
//    options.SaveToken = true;
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = jwtSettings.Issuer,
//        ValidAudience = jwtSettings.Audience,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
//        ClockSkew = TimeSpan.Zero,
//        NameClaimType = "uid"
//    };
//    // Add custom JwtBearerEvents
//    options.Events = new JwtBearerEvents
//    {
//        OnTokenValidated = async ctx =>
//        {
//            var userManager = ctx.HttpContext.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
//            var user = await userManager.FindByNameAsync(ctx.Principal.Identity.Name);

//            if (user != null)
//            {
//                var identity = ctx.Principal.Identity as ClaimsIdentity;
//                if (identity != null)
//                {
//                    // Remove any existing NameIdentifier claim (which might hold the email)
//                    var existingClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
//                    if (existingClaim != null)
//                    {
//                        identity.RemoveClaim(existingClaim);
//                    }

//                    // Add correct user ID as NameIdentifier
//                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
//                }
//            }
//        }
//    };

//});
//var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
//if (jwtSettings == null || string.IsNullOrWhiteSpace(jwtSettings.Issuer) || string.IsNullOrWhiteSpace(jwtSettings.Audience) || string.IsNullOrWhiteSpace(jwtSettings.Key))
//{
//    throw new InvalidOperationException("JwtSettings or its required properties (Issuer, Audience, Key) are not configured properly.");
//}
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.RequireHttpsMetadata = false; // dev only
//        options.SaveToken = true;
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidIssuer = jwtSettings.Issuer,
//            ValidAudience = jwtSettings.Audience,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
//            ClockSkew = TimeSpan.FromMinutes(5),
//            NameClaimType = "uid",  // your user id claim
//            RoleClaimType = ClaimTypes.Role // default role claim
//        };

//        options.Events = new JwtBearerEvents
//        {
//            OnAuthenticationFailed = context =>
//            {
//                Console.WriteLine($"JWT Auth Failed: {context.Exception.Message}");
//                Log.Error(context.Exception, "JWT authentication failed");
//                return Task.CompletedTask;
//            },
//            OnTokenValidated = context =>
//            {
//                var user = context.Principal;
//                var name = user?.Identity?.Name ?? "(no name)";
//                Log.Information("JWT validated for {User}", name);
//                Console.WriteLine($"JWT validated for: {name}");

//                Console.WriteLine("---- JWT Claims ----");
//                foreach (var claim in user.Claims)
//                {
//                    Console.WriteLine($"{claim.Type} = {claim.Value}");
//                    Log.Debug("JWT Claim {Type} = {Value}", claim.Type, claim.Value);
//                }
//                Console.WriteLine("-------------------");

//                return Task.CompletedTask;
//            }
//        };
//    });

// ---------- Register Layers ----------
builder.Services.AddAuthorization();
builder.Services.AddScoped<IUserContext, UserContext>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(configuration);
builder.Services.AddInfrastructureServices(configuration);

// ---------- Swagger with JWT ----------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MC API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] your token"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return Task.CompletedTask;
    };
});

// ---------- Build App ----------
var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseMiddleware<DevAuthenticationBypassMiddleware>();
//}
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use HTTPS Redirection in production
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

// ---------- Middlewares ----------
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

//app.UseMiddleware<RequestLoggingMiddleware>(); // log everything, even unmatched endpoints

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
