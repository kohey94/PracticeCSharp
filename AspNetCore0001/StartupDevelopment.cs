using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCore0001
{
    // Startup.csのファイル名は変更可能
    public class StartupDevelopment
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureProduction(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello ConfigureProduction!");
                });
            });

            // ASP.NET CoreではWebアプリケーションを作成できるがMVCアプリケーションであるとは限らない。
            // MVCアプリケーションを作成したい場合は、MVCサービスを使う設定をしなければいけない。
        }
        public void ConfigureDevelopment(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello ConfigureDevelopment!");
                });
            });

            // ASP.NET CoreではWebアプリケーションを作成できるがMVCアプリケーションであるとは限らない。
            // MVCアプリケーションを作成したい場合は、MVCサービスを使う設定をしなければいけない。
        }
    }
}
