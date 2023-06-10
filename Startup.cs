using Hangfire;
using Microsoft.Extensions;

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
    }
    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        app.UseHangfireDashboard();

        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=home}/{action=index}/{id?}");
        });
        //app.UseRouting();
        //app.UseAuthorization();
        //app.MapRazorPages();
        //app.Run();
    }
}