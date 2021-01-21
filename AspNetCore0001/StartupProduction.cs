using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCore0001
{
    // Startup.cs�̃t�@�C�����͕ύX�\
    public class StartupProduction
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

            // ASP.NET Core�ł�Web�A�v���P�[�V�������쐬�ł��邪MVC�A�v���P�[�V�����ł���Ƃ͌���Ȃ��B
            // MVC�A�v���P�[�V�������쐬�������ꍇ�́AMVC�T�[�r�X���g���ݒ�����Ȃ���΂����Ȃ��B
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

            // ASP.NET Core�ł�Web�A�v���P�[�V�������쐬�ł��邪MVC�A�v���P�[�V�����ł���Ƃ͌���Ȃ��B
            // MVC�A�v���P�[�V�������쐬�������ꍇ�́AMVC�T�[�r�X���g���ݒ�����Ȃ���΂����Ȃ��B
        }
    }
}
