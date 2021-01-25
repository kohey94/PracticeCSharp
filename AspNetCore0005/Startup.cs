using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCore0005
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddMvcCore();
            builder.AddMvcOptions( o =>
            {
                o.EnableEndpointRouting = false;
            });
            builder.AddViews();
            builder.AddRazorViewEngine();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //�ȉ��������Ӗ�
            //app.UseMvcWithDefaultRoute();



            // ���[�g�̐ݒ�Ȃ�
            // app.UseMvc(routes => { });
            // �ȉ��������Ӗ�
            // appd.UseMvc();

            // ���[�g�̐ݒ肪����Ă��Ȃ�URL�ɃA�N�Z�X�����ꍇ�͉��̏��������s�����B
            app.Run(async context =>
            {
                await context.Response.WriteAsync(
                    "I'd rather say there are no configured routes here.");
            });
        }
    }
}
