using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            //app.UseEndpoints(endPoint => {
            //    endPoint.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello from new web Api");
            //    });
            //});
        }

    }
}
