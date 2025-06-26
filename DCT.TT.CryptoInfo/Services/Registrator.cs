using DCT.TT.CryptoInfo.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DCT.TT.CryptoInfo.Services
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<HttpClient>();
            services.AddSingleton<PageService>();
            services.AddSingleton<ICryptoApiService, CryptoApiService>();
            services.AddSingleton<GlobalSettingsService>();
            //register services
            return services;
        }
    }
}
