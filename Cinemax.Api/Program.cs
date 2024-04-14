using Cinemax.Infrastructure;
using Cinemax.Application;
using Cinemax.Api;

var builder = WebApplication.CreateBuilder(args);
{ 
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration).AddPresentation();
    builder.Services.AddControllers().AddNewtonsoftJson();

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
    // Use CORS middleware with the policy
    app.UseCors("AllowAll");
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();

    //app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
    app.Run();
}