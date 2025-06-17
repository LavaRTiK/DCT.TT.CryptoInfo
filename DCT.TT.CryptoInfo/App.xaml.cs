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
        private static IHost _host;
        public static IHost Host => _host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            var host = Host; 
            await host.StopAsync().ConfigureAwait(false);
            host.Dispose();
            _host = null;
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;
            base.OnStartup(e);
            await host.StartAsync().ConfigureAwait(false);
        }

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection service)
        {
            //service.AddSingleton<DataService>();
            service.AddSingleton<CryptoStatiscticViewModel>();
            //request host service
            //App.Host.Services.GetRequiredService<CryptoStatiscticViewModel>();
        }
    }
}
