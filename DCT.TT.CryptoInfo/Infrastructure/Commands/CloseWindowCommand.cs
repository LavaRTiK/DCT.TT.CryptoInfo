using System.Net.Mime;
using System.Windows;
using DCT.TT.CryptoInfo.Infrastructure.Commands.Base;

namespace DCT.TT.CryptoInfo.Infrastructure.Commands
{
    internal class CloseWindowCommand : Command
    {
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
