using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestWithASPNet.Model.Context;
using RestWithASPNet.Services;
using RestWithASPNet.Services.Implementations;

namespace RestWithASPNet
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

            services.AddControllers();

            //Salving the connectionString
            var connection = Configuration["SqlConnection:SqlConnectionString"];

            //Realizing the addition of context in the database
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(connection));

            //Addition service for versioning controller
            services.AddApiVersioning();

            //Dependecy Injection
            services.AddScoped<IPersonService, PersonServiceImplementation>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
