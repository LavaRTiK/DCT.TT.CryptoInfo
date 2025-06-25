using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DCT.TT.CryptoInfo.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
        public Page1ViewModel Page1Model => App.Services.GetRequiredService<Page1ViewModel>();
        public DetailCryptoPageViewModel DetailCryptoPageModel => App.Services.GetRequiredService<DetailCryptoPageViewModel>();
        public SettingsPageViewModel SettingsPageModel => App.Services.GetRequiredService<SettingsPageViewModel>();
    }
}
