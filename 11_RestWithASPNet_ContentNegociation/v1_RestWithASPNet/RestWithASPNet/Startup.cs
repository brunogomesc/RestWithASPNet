using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using RestWithASPNet.Business;
using RestWithASPNet.Business.Implementations;
using RestWithASPNet.Model.Context;
using RestWithASPNet.Repository;
using RestWithASPNet.Repository.Generic;
using Serilog;
using System;
using System.Collections.Generic;

namespace RestWithASPNet
{
    public class Startup
    {

        public IWebHostEnvironment Environment { get; }

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            //Saving the connectionString
            var connection = Configuration["SqlConnection:SqlConnectionString"];

            //Realizing the addition of context in the database
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(connection));

            //if (Environment.IsDevelopment())
            //{

            //    MigrateDatabase(connection);

            //}

            services.AddMvc(options => {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            }).AddXmlSerializerFormatters();

            //Addition service for versioning controller
            services.AddApiVersioning();

            //Dependecy Injection
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IBookBusiness, BookBusinessImplementation>();
            services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
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

        private void MigrateDatabase(string connection)
        {
            try
            {

                var evolveConnection = new Microsoft.Data.SqlClient.SqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {

                    Locations = new List<String> {"db/migrations", "db/dataset" },
                    IsEraseDisabled = true,

                };

                evolve.Migrate();

            }
            catch (Exception ex)
            {

                Log.Error("Database migration failed - Error: " + ex);
                throw;

            }
        }

    }
}
