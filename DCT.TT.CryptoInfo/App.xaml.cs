using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using DCT.TT.CryptoInfo.Services;
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
        public static bool IsDesignMode { get; private set; } = true;
        private static IHost _host;
        public static IHost Host => _host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        public static IServiceProvider Services => Host.Services;

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
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("uk-UA");
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("uk-UA");
            IsDesignMode = false;
            var host = Host;
            base.OnStartup(e);
            await host.StartAsync().ConfigureAwait(false);
        }

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection service)
        {
            service.RegisterServices();

            service.RegisterViewModels();
            //App.Host.Services.GetRequiredService<CryptoStatiscticViewModel>();
        }

        public static string CurrentDirectory => IsDesignMode ? Path.GetDirectoryName(GetSourceCodePath()) : Environment.CurrentDirectory;

        private static string GetSourceCodePath([CallerFilePath] string path = null) => path;
    }
}
