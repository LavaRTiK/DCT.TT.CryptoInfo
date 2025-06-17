using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

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
            hostBuilder.UseContentRoot(Environment.CurrentDirectory);
            hostBuilder.ConfigureAppConfiguration((host, cfg) =>
            {
                cfg.SetBasePath(Environment.CurrentDirectory);
                cfg.AddJsonFile("appsettings.json", true, reloadOnChange: true);
            });
            hostBuilder.ConfigureServices(App.ConfigureServices);

            return hostBuilder;
        }
    }
}
