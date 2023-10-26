using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Schoolmanagment.Middleware;
public class GlobalExceptionHandingMiddlewareConvenet
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandingMiddlewareConvenet> _logger;

    public GlobalExceptionHandingMiddlewareConvenet(ILogger<GlobalExceptionHandingMiddlewareConvenet> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ProblemDetails problem = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = "English : Server Error => Uzbek : Server xatosi",
                Title = "Server Error",
                Detail = "English : An internal server error has occurred => Uzbek : Ichki server xatosi yuz berdi"
            };

            await context.Response.WriteAsJsonAsync($" 500 Problem detail : {problem}");
        }
        if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            ProblemDetails problem = new ProblemDetails
            {
                Status = (int)HttpStatusCode.NotFound,
                Type = "Not Found",
                Title = "Resurce Not Found",
                Detail = "The requested resource was not found"
            };
            await context.Response.WriteAsJsonAsync($" 404 Problem details : {problem}");
        }
        if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            ProblemDetails problem = new ProblemDetails
            {
                Status = (int)HttpStatusCode.Forbidden,
                Type = "Englis : Forbidden => Uzbek : Taqiqlangan",
                Title = "Resurce Forbidden",
                Detail = "The request contained valid data and was understood by the server, but the server is refusing action"
            };
            await context.Response.WriteAsJsonAsync($" 403 Problem details : {problem}");
        }
        if (context.Response.StatusCode == (int)HttpStatusCode.PaymentRequired)
        {
            context.Response.StatusCode = (int)HttpStatusCode.PaymentRequired;
            ProblemDetails problem = new ProblemDetails
            {
                Status = (int)HttpStatusCode.PaymentRequired,
                Type = "Englis : Payment Required => Uzbek : To'lov Talab Qilinadi",
                Title = "Resurce Payment Required",
                Detail = "English : Reserved for future use => Uzbek : Kelajakda foydalanish uchun saqlangan"
            };
            await context.Response.WriteAsJsonAsync($" 402 Problem details : {problem}");
        }
        if (context.Response.StatusCode == (int)HttpStatusCode.ServiceUnavailable)
        {
            context.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
            ProblemDetails problem = new ProblemDetails
            {
                Status = (int)HttpStatusCode.ServiceUnavailable,
                Type = "Englis : Service Unavailable => Uzbek : Xizmat ish faoliyatida emas",
                Title = "Resurce Service Unavailable",
                Detail = "English : The server cannot handle the request => Uzbek : Server so'rovni bajara olmaydi"
            };
            await context.Response.WriteAsJsonAsync($" 503 Problem details : {problem}");
        }
        if(context.Response.StatusCode == (int)HttpStatusCode.PaymentRequired)
        {
            context.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
            ProblemDetails problem = new ProblemDetails
            {
                Status = (int)HttpStatusCode.ServiceUnavailable,
                Type = "English :  Unauthorized => Uzbek : Ruxsatsiz",
                Title = "Redurce  Unauthorized",
                Detail = "English : client request has not been completed => Uzbek : mijoz so'rovi bajarilmagan"
            };
            await context.Response.WriteAsJsonAsync($" 401 Problem details : {problem}");
        }
    }
}
