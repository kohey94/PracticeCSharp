using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Constraints;
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
                    name: "route-date",
                    template: "date/{offset}",
                    defaults: new { controller = "date", action = "day", offset = 0 },
                    constraints: new { offset = new IntRouteConstraint() } // offsetにInt型の制約を付ける
                    );
            });

            // 以下も同じ処理
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "route-date",
            //        template: "date/{offset:int}", // offsetにInt型の制約を付ける
            //        defaults: new { controller = "date", action = "day", offset = 0 }
            //        );
            //});



            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //以下も同じ意味
            //app.UseMvcWithDefaultRoute();



            // ルートの設定なし
            // app.UseMvc(routes => { });
            // 以下も同じ意味
            // appd.UseMvc();

            // ルートの設定がされていないURLにアクセスした場合は下の処理が実行される。
            app.Run(async context =>
            {
                await context.Response.WriteAsync(
                    "I'd rather say there are no configured routes here.");
            });
        }
    }
}
