/*
using Hangfire;
using Microsoft.Extensions;
using Microsoft.Identity.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

public class Startup
{
    public IConfiguration _configuration { get; set; }
    public Startup(IConfiguration Configuration)
    {
        _configuration = Configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHangfire(x => x.UseSqlServerStorage(_configuration.GetConnectionString("DefaultConnection")));
        services.AddHangfireServer();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "SwaggerDemoApplication",
                Version = "v1"
            });
        });
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHangfireDashboard();
        app.UseRouting();
        app.MapControllers();
        app.UseHttpsRedirection();
        app.Run();
    }
}

*/