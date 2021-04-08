using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuotesManagement.Areas.Identity.Data;
using QuotesManagement.Data;

[assembly: HostingStartup(typeof(QuotesManagement.Areas.Identity.IdentityHostingStartup))]
namespace QuotesManagement.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<AuthDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("QuotesManagementDB")));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;

                })
                    .AddEntityFrameworkStores<AuthDBContext>();
            });


        }
    }
}
