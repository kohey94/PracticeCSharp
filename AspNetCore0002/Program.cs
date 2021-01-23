using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AspNetCore0002
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Program.csの中でもHTTPリクエストをみることができるため、Startup.csがなくても動かすことはできる。
            // http://localhost:5000
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseIISIntegration()
                .Configure(app =>
                {
                    app.Run(async (context) =>
                    {
                        var path = context.Request.Path;
                        await context.Response.WriteAsync("<h1>" + path + "</h1>");
                    });
                })
                .Build();
            host.Run();
        }
    }
}
