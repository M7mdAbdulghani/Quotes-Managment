using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QuotesManagement.Areas.Identity.Data;
using QuotesManagement.Data;
using System.Linq;
using System.Text;

namespace QuotesManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<QuotesManagementDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("QuotesManagementDB"));
            });

            services.AddDbContextPool<AuthDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("QuotesManagementDB"));
            });


            services.AddScoped<IQuoteData, SqlQuoteData>();
            services.AddScoped<IAuthorData, SqlAuthorData>();


            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<AuthDBContext>()
            .AddDefaultTokenProviders();



            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials().Build());
            });


            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = Configuration["JWT:Issuer"],
                            ValidAudience = Configuration["JWT:Issuer"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                        };
                    });


            services.AddMvc();
            services.AddControllers();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Quotes Management API", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Quotes Management API");
            });



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
