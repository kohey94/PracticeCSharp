using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore0003.Persistence.Abstractions;
using AspNetCore0003.Persistence.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace AspNetCore0003
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICountryRepository>(new CountryRepository());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider provider)
        {
            app.Map("/country", countryApp =>
            {
                countryApp.Run(async context =>
                {
                    // Å´Ç±ÇÍÇæÇ∆ìÆÇ©Ç»Ç©Ç¡ÇΩ
                    //var country = provider.GetService<ICountryRepository>();
                    // Å´Ç±ÇÍÇ≈ìÆÇ¢ÇΩ éQçlURL:https://stackoverflow.com/questions/50619696/net-core-2-1-cannot-access-a-disposed-object-object-name-iserviceprovider
                    var country = app.ApplicationServices.GetService<ICountryRepository>();
                    var query = context.Request.Query["q"];
                    var list = country.AllBy(query).ToList();
                    var json = JsonConvert.SerializeObject(list);

                    await context.Response.WriteAsync(json);
                });
            });

            // Work as a catch-all
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Invalid call");
            });
            
        }
    }
}
