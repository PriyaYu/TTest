using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Nexify_Engineer_Test_BackEnd.Models;

namespace Nexify_Engineer_Test_BackEnd
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlite("Data Source=Nexify_Engineer_Test.db"));
            services.AddDbContext<Nexify_Engineer_Test_BackEnd.Models.AppDbContext>(options => options.UseSqlite("Data Source=Nexify_Engineer_Test.db"));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
