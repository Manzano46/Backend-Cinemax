using Cinemax.Infrastructure;
using Cinemax.Application;

var builder = WebApplication.CreateBuilder(args);
{ 
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();

    // Add CORS services
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", 
            builder => builder.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader());
    });
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();

    // Use CORS middleware with the policy
    app.UseCors("AllowAll");

    app.MapControllers();
    app.Run();
}