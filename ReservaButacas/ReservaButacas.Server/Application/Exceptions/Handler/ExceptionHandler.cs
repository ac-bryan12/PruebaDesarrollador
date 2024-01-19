using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ReservaButacas.Server.Application.Exceptions;

public class ExceptionHandler
{
    private readonly RequestDelegate _next;

    public ExceptionHandler(RequestDelegate next)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
    }

    public async Task Invoke(HttpContext contexto)
    {
        try
        {
            await _next(contexto);
        }
        catch (CustomException customEx)
        {
            await HandleExceptionAsync(contexto, customEx, HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(contexto, ex, HttpStatusCode.InternalServerError);
        }
    }

    private static Task HandleExceptionAsync(HttpContext contexto, Exception ex, HttpStatusCode status)
    {
        var result = JsonConvert.SerializeObject(new { error = ex.Message });
        contexto.Response.ContentType = "application/json";
        contexto.Response.StatusCode = (int)status;
        return contexto.Response.WriteAsync(result);
    }
}

