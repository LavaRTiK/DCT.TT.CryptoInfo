using DCT.TT.CryptoInfo.Infrastructure.Commands;
using DCT.TT.CryptoInfo.Services;
using DCT.TT.CryptoInfo.ViewModels.Base;
using DCT.TT.CryptoInfo.Views.Page;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using DCT.TT.CryptoInfo.Services.Interface;

namespace DCT.TT.CryptoInfo.ViewModels
{
    [MarkupExtensionReturnType(typeof(MainWindowViewModel))]
    internal class MainWindowViewModel : ViewModelBase
    {
        private DispatcherTimer timer = null;
        private ICryptoApiService _cryptoApiService;
        #region Property

        #region page

        private readonly PageService _pageService;
        private Page _pageSource;

        public Page PageSource
        {
            get => _pageSource;
            set
            {
                Set(ref _pageSource,value);
            }
        }
        #endregion
        #region Titel
        private string _Title = "Crypto Info App";
        public string Title
        {
            get => _Title;
            set
            {
                Set(ref _Title, value);
            }
        }
        #endregion

        #endregion

        private string _statusApi;

        public string StatusApi
        {
            get => _statusApi;
            set
            {
                Set(ref _statusApi, value);
            }
        }

        #region Commands

        #region ChangePageSettings

        public ICommand ChangePageSetting { get; }

        private bool CanChangePageSettingExcecute(object p) => true;

        private void OnChangePageSettingExcecuted(object p)
        {
            Debug.WriteLine("переход к настройкам");
            _pageService.ChangePage(new SettingsPage());
        }
        #endregion
        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApllicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion
        #endregion
        public MainWindowViewModel(PageService pageService,ICryptoApiService cryptoApiService)
        {
            //TEST
            Debug.WriteLine(System.Threading.Thread.CurrentThread.CurrentUICulture.Name);
            StatusApi = "Offline";
            _cryptoApiService = cryptoApiService;
            _pageService = pageService;
            _pageService.OnPageChanged += (page) => PageSource = page;
            _pageService.ChangePage(new Page1());
            //_pageService.ChangePage(new DetailCryptoPage());
            #region Commands
            CloseApplicationCommand = new LambdaCommand(OnCloseApllicationCommandExecuted,CanCloseApplicationCommandExecute);
            ChangePageSetting = new LambdaCommand(OnChangePageSettingExcecuted, CanChangePageSettingExcecute);
            timeStart();

            #endregion
        }

        private void timeStart()
        {
            timer = new DispatcherTimer(DispatcherPriority.Render);
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 60,0);
            timer.Start();
        }
        private async void timerTick(object sender, EventArgs e)
        {
            Debug.WriteLine("cheak api");
            StatusApi = "Request..";
            bool cheak = await _cryptoApiService.Ping();
            if (cheak)
            {
                StatusApi = "Online";
            }
            else
            {
                StatusApi = "Offline";
            }
        }
    }
}
