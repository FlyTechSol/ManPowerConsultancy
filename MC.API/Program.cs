using MC.API.Extensions;
using MC.API.Middlewares;
using MC.Application;
using MC.Application.Contracts.Identity;
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
using Serilog;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// ---------- Serilog ----------
builder.Host.UseSerilog((ctx, lc) =>
    lc.ReadFrom.Configuration(ctx.Configuration).WriteTo.Console());

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

// ---------- Register Layers ----------
builder.Services.AddScoped<IUserContext, UserContext>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(configuration);
builder.Services.AddInfrastructureServices(configuration);

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
var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
if (jwtSettings == null || string.IsNullOrWhiteSpace(jwtSettings.Issuer) || string.IsNullOrWhiteSpace(jwtSettings.Audience) || string.IsNullOrWhiteSpace(jwtSettings.Key))
{
    throw new InvalidOperationException("JwtSettings or its required properties (Issuer, Audience, Key) are not configured properly.");
}
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
            ClockSkew = TimeSpan.Zero,
            NameClaimType = "uid"
        };
    });

builder.Services.AddAuthorization();

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

// ---------- Build App ----------
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMiddleware<DevAuthenticationBypassMiddleware>();
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

app.UseHttpsRedirection();

// Global Exception Handler
app.UseGlobalExceptionHandler();

app.UseCors("CorsPolicy");
//app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
