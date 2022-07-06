using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class JsonConverterMiddleware
{
    private RequestDelegate _next;
    public JsonConverterMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        await _next.Invoke(context);
    }
}