using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tamga_Test_WebApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tamga_Test_WebApp
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

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
           // dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();
            DataBaseSeed(dbContext);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        #region DB Seed
        private void DataBaseSeed(ApplicationDbContext dbContext)
        {
            /*Companies*/
            dbContext.Companies.Add(new Models.Company() { Address = "Adress company 1", Name = "Company 1", Phone = "+380111111111" });
            dbContext.Companies.Add(new Models.Company() { Address = "Adress company 2", Name = "Company 2", Phone = "+380222222222" });
            var company_3 = new Models.Company() { Address = "Adress company 3", Name = "Company 3", Phone = "+380222222222" };
            dbContext.Companies.Add(company_3);
            var company_4 = new Models.Company() { Address = "Adress company 4", Name = "Company 4", Phone = "+380222222222" };
            dbContext.Companies.Add(company_4);

            /*Positions*/
            var position_1 = new Models.Position() { Name = "Position 1", SalaryForkMax = 22222, SalaryForkMin = 120, Company = company_4 };
            dbContext.Positions.Add(position_1);
            var position_2 = new Models.Position() { Name = "Position 2", SalaryForkMax = 2120, SalaryForkMin = 800 };
            dbContext.Positions.Add(position_2);
            dbContext.Positions.Add(new Models.Position() { Name = "Position 3", SalaryForkMax = 1111, SalaryForkMin = 455 });
            dbContext.Positions.Add(new Models.Position() { Name = "Position 4", SalaryForkMax = 123, SalaryForkMin = 11 , Company=company_3});


            /*Applicants*/

            dbContext.Applicants.Add(new Models.Applicant() { Age = 54, Name = "Applicant 1", LastName = "app 111", Phone = "+380123456789", PretendedSalary = 500 });
            dbContext.Applicants.Add(new Models.Applicant() { Age = 22, Name = "Applicant 2", LastName = "app 222222", Phone = "+380123422222", PretendedSalary = 500 });
            var applicant_3 = new Models.Applicant() { Age = 32, Name = "Applicant 3", LastName = "app 33333", Phone = "+380123456444", PretendedSalary = 500, Position=position_1 };
            dbContext.Applicants.Add(applicant_3);
            var applicant_4 = new Models.Applicant() { Age = 18, Name = "Applicant 4", LastName = "app 1444", Phone = "+380124444449", PretendedSalary = 15000, Position=position_1 };
            dbContext.Applicants.Add(applicant_4);

            dbContext.SaveChanges();



        }
        #endregion
    }
}
