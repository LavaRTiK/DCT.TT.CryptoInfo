using DCT.TT.CryptoInfo.Infrastructure.Commands;
using DCT.TT.CryptoInfo.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DCT.TT.CryptoInfo.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private string _Title = "CryptoInfo";
        public string Title
        {
            get => _Title;
            set
            {
                Set(ref _Title, value);
            }
        }
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
        public MainWindowViewModel()
        {
            #region Commands
            CloseApplicationCommand = new LambdaCommand(OnCloseApllicationCommandExecuted,CanCloseApplicationCommandExecute);
            #endregion
        }
    }
}
