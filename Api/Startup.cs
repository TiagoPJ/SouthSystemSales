using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api
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
            // Register Watcher
            new WatcherConfig(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider)
        {

            #region Custom Middlewares            
            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.Run(async (context) =>
            {
                var path = $"{Environment.GetEnvironmentVariable("HOMEPATH")}{Configuration.GetValue<string>("Paths:InDirectory").Replace(@"/", @"\")}";
            
                await context.Response.WriteAsync(string.Format("Projeto está executando neste momento, inserir os arquivos '.dat' dentro da pasta {0}.", path));
            });
        }
    }
}
