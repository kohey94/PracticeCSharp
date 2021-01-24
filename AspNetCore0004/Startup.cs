using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace AspNetCore0004
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // wwwroot����̃t�@�C���񋟂��\�ɂ���B
            app.UseStaticFiles();

            // Assets����̃t�@�C���񋟂��\�ɂ���B
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"Assets")),
                RequestPath = new PathString("/Public/Assets")
            });
        }
    }
}
