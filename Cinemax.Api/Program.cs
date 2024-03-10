using BuberDinner.Infrastructure;
using Cinemax.Application;
using Cinemax.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{ 
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
 