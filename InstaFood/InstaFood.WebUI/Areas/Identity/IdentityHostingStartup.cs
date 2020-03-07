using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(InstaFood.WebUI.Areas.Identity.IdentityHostingStartup))]
namespace InstaFood.WebUI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}