using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DCT.TT.CryptoInfo.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DCT.TT.CryptoInfo
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void ConfigureServices(HostBuilderContext host, IServiceCollection service)
        {
            //service.AddSingleton<DataService>();
            service.AddSingleton<CryptoStatiscticViewModel>();
        }
    }
}
