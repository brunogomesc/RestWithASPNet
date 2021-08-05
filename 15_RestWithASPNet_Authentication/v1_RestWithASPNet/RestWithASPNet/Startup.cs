using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using RestWithASPNet.Business;
using RestWithASPNet.Business.Implementations;
using RestWithASPNet.Configurations;
using RestWithASPNet.Hypermedia.Enricher;
using RestWithASPNet.Hypermedia.Filters;
using RestWithASPNet.Model.Context;
using RestWithASPNet.Repository;
using RestWithASPNet.Repository.Generic;
using RestWithASPNet.Services;
using RestWithASPNet.Services.Implementations;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

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

            var tokenConfigurations = new TokenConfiguration();

            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                Configuration.GetSection("TokenConfigurations")    
            ).Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(options =>  {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters { 
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenConfigurations.Issuer,
                    ValidAudience = tokenConfigurations.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurations.Secret))
                };

            });

            services.AddAuthorization(auth => {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder().AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build());
            });

            services.AddCors(options => options.AddDefaultPolicy(builder => {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

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

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
            filterOptions.ContentResponseEnricherList.Add(new BookEnricher());

            services.AddSingleton(filterOptions);

            //Addition service for versioning controller
            services.AddApiVersioning();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "REST API's with ASP .NET Core 5",
                    Version = "v1",
                    Description = "API RESTfull with ASP .NET Core 5",
                    Contact = new OpenApiContact
                    {
                        Name = "Bruno Costa",
                        Url = new Uri("https://github.com/brunogomesc")
                    }
                });
            });

            //Dependecy Injection
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IBookBusiness, BookBusinessImplementation>();
            services.AddScoped<ILoginBusiness, LoginBusinessImplementation>();
            services.AddTransient<ITokenService, TokenService>();

            services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();

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

            app.UseCors();

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "REST API's with ASP .NET Core 5 - v1");
            });

            var option = new RewriteOptions();

            option.AddRedirect("^$","swagger");

            app.UseRewriter(option);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
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
