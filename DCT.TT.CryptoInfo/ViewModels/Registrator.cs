using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DCT.TT.CryptoInfo.Services;
using DCT.TT.CryptoInfo.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace DCT.TT.CryptoInfo.ViewModels
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection service)
        {
            //register ViewModels
            service.AddTransient<MainWindowViewModel>();
            service.AddTransient<Page1ViewModel>();
            service.AddTransient<DetailCryptoPageViewModel>();
            return service;
        }
    }
}
