using DCT.TT.CryptoInfo.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
