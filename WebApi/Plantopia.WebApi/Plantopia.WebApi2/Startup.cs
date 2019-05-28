using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Plantopia.Service.Auth;
using Plantopia.WebApi.Data.Model;
using Plantopia.WebApi.Providers;
using Plantopia.WebApi.Swagger;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Plantopia.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings{env.EnvironmentName}.json", true)
                .AddJsonFile("appsettings.secret.json", false, true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(AuthOptions.TokenProvider.ValidateOptions);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // 'scoped' in ASP.NET means "per HTTP request"
            services.AddScoped(
                _ => new PlantopiaDataContext(Configuration.GetConnectionString("DefaultConnection")));

            // api Versioning
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Info { Version = "v1.0", Title = "API V1.0" });
                c.SwaggerDoc("v1.1", new Info { Version = "v1.1", Title = "API V1.1" });

                string filePath = Path.Combine(AppContext.BaseDirectory, "Plantopia.WebApi.xml");
                if (File.Exists(filePath))
                {
                    c.IncludeXmlComments(filePath);
                }
                else
                {
                    Debug.Write("Swagger comments not found");
                }
                c.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                    IEnumerable<ApiVersion> versions = methodInfo.DeclaringType
                        .GetCustomAttributes(true)
                        .OfType<ApiVersionAttribute>()
                        // ReSharper disable once TooManyChainedReferences
                        .SelectMany(attr => attr.Versions);

                    return versions.Any(v => $"v{v.ToString()}" == docName);
                });

                c.OperationFilter<RemoveVersionParameters>();
                c.DocumentFilter<SetVersionInPaths>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // To design Swashbuckle components in a corporate style,
            // you need to add resources to serve static files
            // and then build a folder structure to accommodate them.
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "My API V1");
                c.SwaggerEndpoint("/swagger/v1.1/swagger.json", "My API V1.1");
                c.RoutePrefix = string.Empty;
            });

            // Enable middleware to generated logs as a text file.
            LoggerConfiguration(loggerFactory);

            // TODO: remove on Release
            // if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseCors(builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.UseMvc();
        }

        /// <summary>
        /// Configure the logger data format and file location
        /// </summary>
        /// <param name="loggerFactory"></param>
        public void LoggerConfiguration(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                $"log/#log-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.txt"));
            ILogger logger = loggerFactory.CreateLogger("FileLogger");
            logger.LogInformation("Processing request {0}", 0);
        }
    }
}
