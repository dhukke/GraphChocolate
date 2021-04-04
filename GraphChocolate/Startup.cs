using System;
using GraphChocolate.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GraphChocolate
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // CORS
            var cors = Environment.GetEnvironmentVariable("CORS");
            var origins = cors?.Split(',', StringSplitOptions.RemoveEmptyEntries);

            if (origins == null || origins.Length == 0)
            {
                origins = new string[] { "http://localhost", "http://localhost:8080" };
            }

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins(origins)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services
                .AddPooledDbContextFactory<PizzaContext>(
                    (s, o) => o
                        .UseSqlServer(
                            "Server=localhost,1433;User ID=sa;Password=yourStrong(!)Password;Initial Catalog=pizzas;"
                        )
                        .UseLoggerFactory(s.GetRequiredService<ILoggerFactory>()))
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddProjections()
                .AddFiltering()
                .AddSorting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
