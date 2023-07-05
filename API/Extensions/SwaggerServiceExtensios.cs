namespace API.Extensions;

public static class SwaggerServiceExtensios
{
    public static IServiceCollection AddSwaggerService(this IServiceCollection services)
    {

        return services.AddSwaggerService();
    }
    public static IApplicationBuilder UseSwaggerDocumentaion(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }
}
