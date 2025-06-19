using DCT.TT.CryptoInfo.Infrastructure.Commands;
using DCT.TT.CryptoInfo.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using DCT.TT.CryptoInfo.Services;
using DCT.TT.CryptoInfo.Views.Page;

namespace DCT.TT.CryptoInfo.ViewModels
{
    [MarkupExtensionReturnType(typeof(MainWindowViewModel))]
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Property

        #region page

        private readonly PageService _pageService;
        public Page PageSource { get; set; }

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
        #region Commands
        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApllicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion
        #endregion
        public MainWindowViewModel(PageService pageService)
        {
            _pageService = pageService;
            _pageService.OnPageChanged += (page) => PageSource = page;
            _pageService.ChangePage(new Page1());
            #region Commands
            CloseApplicationCommand = new LambdaCommand(OnCloseApllicationCommandExecuted,CanCloseApplicationCommandExecute);
            #endregion
        }
    }
}
