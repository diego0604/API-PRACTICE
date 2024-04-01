namespace Api.Middleware
{
    public class xApiKey
    {
        private readonly RequestDelegate _next; 
        private const string _APIKEY = "xApiKey";

        public xApiKey(RequestDelegate next) {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context) { 
        
            if(!context.Request.Headers.TryGetValue(_APIKEY, out var extractedApiKey))
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Necesita el apikey' :b");
                return;
            }
            var config = context.RequestServices.GetRequiredService<IConfiguration>();
            if (!config.GetSection("xApiKey").Value!.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("no autorizao'' :b");
                return;
            }
            await _next(context);
        
        }
        

    }
}
