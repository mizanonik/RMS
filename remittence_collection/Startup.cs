using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using remittence_collection.BLL;
using remittence_collection.Models;
using remittence_collection.Repository;

namespace remittence_collection
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<RemittenceCollectionContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("RemitterCollectionContext")));
            services.AddControllers();
            services.AddScoped<IRemitterRegistration, RemitterRegistration>();
            services.AddScoped<IRemitterRegistrationBLL, RemitterRegistrationBLL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<RemittenceCollectionContext>();
                context.Database.Migrate();

                var country = context.Countries.FirstOrDefault();
                if(country == null){
                    context.Countries.Add(new Country{Code= "BD", Name = "Bangladesh"});
                    context.Countries.Add(new Country{Code= "SGP", Name = "Singapore"});
                }
                var IDType = context.IDTypes.FirstOrDefault();
                if(IDType == null){
                    context.IDTypes.Add(new IDType{TypeName="NID"});
                    context.IDTypes.Add(new IDType{TypeName="Passport"});
                }
                var remitterType = context.RemitterTypes.FirstOrDefault();
                if(remitterType == null){
                    context.RemitterTypes.Add(new RemitterType{TypeName="Individual"});
                    context.RemitterTypes.Add(new RemitterType{TypeName="Corporate"});
                }
                var states = context.States.FirstOrDefault();
                if(states == null){
                    context.States.Add(new State{Code="CTG", Name="Chittagong", CountryId=1});
                    context.States.Add(new State{Code="DHK", Name="Dhaka", CountryId=1});
                    context.States.Add(new State{Code="RAJ", Name="Rajshahi", CountryId=1});
                }
                context.SaveChanges();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
