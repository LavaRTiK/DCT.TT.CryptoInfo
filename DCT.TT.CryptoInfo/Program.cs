using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace DCT.TT.CryptoInfo
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();  
        }
        //fix entity Framework
        public static IHostBuilder CreateHostBuilder(string[] Args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(Args);
            hostBuilder.UseContentRoot(App.CurrentDirectory);
            hostBuilder.ConfigureAppConfiguration((host, cfg) =>
            {
                cfg.SetBasePath(App.CurrentDirectory);
                cfg.AddJsonFile("appsettings.json", true, reloadOnChange: true);
            });
            hostBuilder.ConfigureServices(App.ConfigureServices);

            return hostBuilder;
        }
    }
}
