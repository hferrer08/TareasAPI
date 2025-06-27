using System.Net;
using System.Text.Json;

namespace TareasAPI.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorMiddleware> _logger;

        public ErrorMiddleware(RequestDelegate next, ILogger<ErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Continua con la solicitud
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error inesperado");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var resultado = JsonSerializer.Serialize(new
            {
                mensaje = "Ha ocurrido un error en el servidor.",
                detalle = ex.Message
            });

            return context.Response.WriteAsync(resultado);
        }
    }
}