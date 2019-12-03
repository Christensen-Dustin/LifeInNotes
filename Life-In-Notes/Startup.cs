using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Life_In_Notes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Session;

namespace Life_In_Notes
{
    public class Startup
    {
        // Private Variable to allow Dependency Injection
        private IConfiguration _config;

        // Constructor to allow Dependency Injection for CONFIGURATION
        public Startup(IConfiguration config)
        {
            _config = config;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // setup for a database to a SQLserver - PostgreSQL works with netstandard2.1, not netcoreapp2.2
            services.AddDbContextPool<AppDBContext>(options => options.UseSqlServer(_config.GetConnectionString("EntryDBConnection")));

            // setup for the Indentity User Class, to create Accounts
            services.AddIdentity<Account, IdentityRole>(options =>
            {
                // Configuration of Password requirements
                options.Password.RequiredLength = 7;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDBContext>();
            
            // Adds the full MVC services to the ConfigureServices.
            // AddMvcCore() is a lighter weight version, Core services.
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlSerializerFormatters();

            // Creates an instance of the Repositories
            services.AddScoped<IEntryRepository, SQLEntryRepository>();
            services.AddScoped<INoteRepository, SQLNoteRepository>();

            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
                              ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                // Customizing the UseDeveloperExceptionPage, by increasing the
                // number of lines displayed on the Developer Exception Page
                DeveloperExceptionPageOptions options = new DeveloperExceptionPageOptions
                {
                    SourceCodeLineCount = 13
                };

                app.UseDeveloperExceptionPage(options);
            }
            else
            {
                // Global Exception Handler
                app.UseExceptionHandler("/Error");

                // Re-Executes and generates an Error Page
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            // Reads static files
            app.UseStaticFiles();

            // Setup for user Authentication
            app.UseAuthentication();

            // Setup for Session variables
            app.UseSession();

            // Setup to use MVC
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
