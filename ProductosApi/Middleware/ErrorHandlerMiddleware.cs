public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(
        RequestDelegate next,
        ILogger<ErrorHandlerMiddleware> logger)
    {
        _next   = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext ctx)
    {
        try
        {
            await _next(ctx);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error no manejado");
            await HandleExceptionAsync(ctx, ex);
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext ctx, Exception ex)
    {
        ctx.Response.ContentType = "application/json";

        (ctx.Response.StatusCode, var msg) = ex switch
        {
            KeyNotFoundException        => (404, ex.Message),
            UnauthorizedAccessException => (401, "No autorizado"),
            ArgumentException           => (400, ex.Message),
            _                           => (500, "Error interno del servidor")
        };

        var error = new
        {
            status    = ctx.Response.StatusCode,
            message   = msg,
            timestamp = DateTime.UtcNow
        };

        await ctx.Response.WriteAsJsonAsync(error);
    }
}