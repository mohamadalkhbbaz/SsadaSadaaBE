using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepoPattern.Core.Repositories;
using RepoPattern.EF;
using RepoPattern.EF.Repositories;

namespace RepoPattern.Api
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Create services to the container.
            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("Default")
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // Configure Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Your API", Version = "v1" });
            });

            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddTransient(typeof(IBookRepository), typeof(BookRepository));

        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Enable Swagger and Swagger UI
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
                });
            }

            // Create the following line to include routing middleware
            app.UseRouting();

            // Configure endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHttpsRedirection();
            app.UseAuthorization();


        }
    }
}
