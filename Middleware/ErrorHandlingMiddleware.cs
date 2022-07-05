using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

public class ErrorHandlingMiddleware
{
    private RequestDelegate _next;
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception e)
        {
            await context.Response.WriteAsync($"{e.Message} Status code: 500");
        }

        switch (context.Response.StatusCode)
        {
            case 403:
                await context.Response.WriteAsync("Access Denied");
                break;
            case 404:
                await context.Response.WriteAsync("Not Found");
                break;
            default:
                break;
        }
    }
}
