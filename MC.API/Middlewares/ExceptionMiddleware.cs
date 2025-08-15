using MC.Application.Exceptions;
using MC.Domain.Entity.Exception;
using MC.Shared.Exception;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;

namespace MC.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var request = context.Request;
                var ip = context.Connection.RemoteIpAddress?.ToString();

                if (context.Request.Headers.TryGetValue("X-Forwarded-For", out var headerIp))
                {
                    ip = headerIp.ToString().Split(',').FirstOrDefault();
                }

                if (ip == "::1") ip = "127.0.0.1";

                var log = new
                {
                    Method = request.Method,
                    Path = request.Path,
                    Query = request.QueryString.ToString(),
                    Agent = request.Headers["User-Agent"].ToString(),
                    Ip = ip,
                    Exception = ex.Message,
                    Stack = ex.StackTrace,
                    Inner = GetInnerExceptionDetails(ex),
                    Timestamp = DateTime.UtcNow
                };

                //_logger.LogError("Unhandled Exception: {ExceptionDetail}", JsonSerializer.Serialize(log));
                _logger.LogError(ex, "Unhandled Exception: {ExceptionDetail}", JsonSerializer.Serialize(log));
                await LogToDatabaseAsync(log);

                await HandleExceptionAsync(context, ex);    
            }
        }

        private string GetInnerExceptionDetails(Exception ex)
        {
            if (ex.InnerException == null) return "No inner exception";

            var details = ex.InnerException.Message;
            if (ex.InnerException.InnerException != null)
            {
                details += " → " + GetInnerExceptionDetails(ex.InnerException);
            }
            return details;
        }

        private async Task LogToDatabaseAsync(dynamic log)
        {
            //try
            //{
            //    using var scope = _scopeFactory.CreateScope();
            //    var db = scope.ServiceProvider.GetRequiredService<AppDBContext>();

            //    var exceptionLog = new ExceptionLog
            //    {
            //        Method = log.Method,
            //        Page = log.Path,
            //        Component = "API",
            //        ExceptionMessage = log.Exception,
            //        StackTrace = log.Stack,
            //        InnerException = log.Inner,
            //        IpAddress = log.Ip,
            //        QueryString = log.Query,
            //        Timestamp = log.Timestamp,
            //        UserAgent = log.Agent
            //    };

            //    db.ExceptionLogs.Add(exceptionLog);
            //    await db.SaveChangesAsync();
            //}
            //catch (Exception logEx)
            //{
            //    _logger.LogError("Failed to write exception to DB: {LogEx}", logEx);
            //}
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var status = HttpStatusCode.InternalServerError;
            var problem = CreateProblemDetails(ex, ref status);

            context.Response.StatusCode = (int)status;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(problem);
        }

        private CustomProblemDetails CreateProblemDetails(Exception ex, ref HttpStatusCode status)
        {
            CustomProblemDetails problem;

            switch (ex)
            {
                case BadRequestException badRequest:
                    status = HttpStatusCode.BadRequest;
                    problem = new CustomProblemDetails
                    {
                        Title = "Bad Request",
                        Status = (int)status,
                        Type = nameof(BadRequestException),
                        Detail = badRequest.Message,
                        DisplayError = badRequest.Message,
                        Errors = badRequest.ValidationErrors?.ToDictionary(k => k.Key, v => v.Value.FirstOrDefault() ?? "")
                    };
                    break;

                case NotFoundException notFound:
                    status = HttpStatusCode.NotFound;
                    problem = new CustomProblemDetails
                    {
                        Title = "Not Found",
                        Status = (int)status,
                        Type = nameof(NotFoundException),
                        Detail = $"Resource '{notFound.ResourceName}' with key '{notFound.ResourceKey}' not found.",
                        DisplayError = notFound.Message
                    };
                    break;

                case ValidationException validation:
                    status = HttpStatusCode.UnprocessableEntity;
                    problem = new CustomProblemDetails
                    {
                        Title = "Validation Error",
                        Status = (int)status,
                        Type = nameof(ValidationException),
                        Detail = validation.Message,
                        DisplayError = validation.Message,
                        Errors = new Dictionary<string, string>
                            {
                                { validation.InvalidField ?? "Unknown", validation.Message }
                            }
                    };
                    break;

                case DbUpdateException dbEx:
                    status = HttpStatusCode.BadRequest;
                    problem = new CustomProblemDetails
                    {
                        Title = "Database Error",
                        Status = (int)status,
                        Type = nameof(DbUpdateException),
                        Detail = dbEx.Message,
                        DisplayError = "A database error occurred."
                    };
                    break;

                case UnauthorizedAccessException uae:
                    status = HttpStatusCode.Unauthorized;
                    problem = new CustomProblemDetails
                    {
                        Title = "Unauthorized Access",
                        Status = (int)status,
                        Type = nameof(UnauthorizedAccessException),
                        Detail = uae.Message,
                        DisplayError = "You are not authorized to perform this action."
                    };
                    break;

                case ArgumentNullException ane:
                    status = HttpStatusCode.BadRequest;
                    problem = new CustomProblemDetails
                    {
                        Title = "Argument Null Exception",
                        Status = (int)status,
                        Type = nameof(ArgumentNullException),
                        Detail = $"Missing parameter: {ane.ParamName}",
                        DisplayError = ane.Message
                    };
                    break;

                case ArgumentException ae:
                    status = HttpStatusCode.BadRequest;
                    problem = new CustomProblemDetails
                    {
                        Title = "Argument Exception",
                        Status = (int)status,
                        Type = nameof(ArgumentException),
                        Detail = ae.Message,
                        DisplayError = ae.Message
                    };
                    break;

                case TimeoutException te:
                    status = HttpStatusCode.RequestTimeout;
                    problem = new CustomProblemDetails
                    {
                        Title = "Timeout",
                        Status = (int)status,
                        Type = nameof(TimeoutException),
                        Detail = "The operation timed out. Please try again.",
                        DisplayError = "Request timeout occurred."
                    };
                    break;

                case OperationCanceledException oce:
                    status = HttpStatusCode.RequestTimeout;
                    problem = new CustomProblemDetails
                    {
                        Title = "Operation Cancelled",
                        Status = (int)status,
                        Type = nameof(OperationCanceledException),
                        Detail = "The request was cancelled, possibly due to timeout or user cancellation.",
                        DisplayError = "Request was cancelled."
                    };
                    break;

                default:
                    status = HttpStatusCode.InternalServerError;
                    problem = new CustomProblemDetails
                    {
                        Title = "Unexpected Error",
                        Status = (int)status,
                        Type = nameof(Exception),
                        Detail = ex.Message,
                        DisplayError = "An unexpected error occurred."
                    };
                    break;
            }

            return problem;
        }

    }
}