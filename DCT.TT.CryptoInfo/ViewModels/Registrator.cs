using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DCT.TT.CryptoInfo.ViewModels
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection service)
        {
            //register ViewModels
            service.AddSingleton<MainWindowViewModel>();
            service.AddSingleton<CryptoStatiscticViewModel>();

            return service;
        }
    }
}
