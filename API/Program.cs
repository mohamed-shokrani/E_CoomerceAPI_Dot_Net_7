using API.Middlerware;
using Infrastructre.Data;
using Microsoft.EntityFrameworkCore;
using API.Extensions;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString
    ("DefaultConnectionString")));
// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddCors();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .AllowAnyOrigin()
    .WithOrigins("https://localhost:4200"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

// so when the request comes into our api server and we do not have an endpoint 
// that matches that particular requset then we gonna hit this middler and gonna redirect to error controller
app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseSwaggerDocumentaion();
app.MapControllers();
using var scope = app.Services.CreateScope();
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
       // await context.Database.MigrateAsync();//this is gonna apply any pending migrations 
                                              // for the context to the database and it will create the database if it does not already exist

    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex.Message);
    }
}

app.UseRouting();
app.Run();


