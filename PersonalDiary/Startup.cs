using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonalDiary.DataAccess.Contracts;
using PersonalDiary.DataAccess.Reporitories;
using PersonalDiary.Database.Context;
using AutoMapper;

namespace PersonalDiary
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices (IServiceCollection services)
        {
            services.AddDbContext<PersonalDiaryDbContext> (options =>
            {
                options.UseSqlServer (Configuration.GetConnectionString ("DbConnection"));
            });

            services.AddScoped<IDailySummaryReporitory, DailySummaryRepository> ();

#pragma warning disable CS0618 // Type or member is obsolete
            services.AddAutoMapper ();
#pragma warning restore CS0618 // Type or member is obsolete

            services.AddControllersWithViews ();
        }

        public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment ())
            {
                app.UseDeveloperExceptionPage ();
            }

            app.UseHttpsRedirection ();
            app.UseStaticFiles ();

            app.UseRouting ();

            app.UseEndpoints (endpoints =>
            {
                endpoints.MapControllerRoute (
                    name: "default",
                    pattern: "{controller=DailySummary}/{action=Index}/{id?}");
            });
        }
    }
}
