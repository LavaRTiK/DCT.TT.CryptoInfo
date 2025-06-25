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
using System.Windows.Input;
using System.Windows.Markup;

namespace DCT.TT.CryptoInfo.ViewModels
{
    [MarkupExtensionReturnType(typeof(DetailCryptoPageViewModel))]
    internal class DetailCryptoPageViewModel : ViewModelBase
    {
        private PageService _pageService;
        #region Property


        #endregion

        #region Command

        public ICommand ChangePageBack { get; }

        private bool CanChangePageBackExcecute(object p) => true;
        private void OnChangePageBackExcecuted(object p)
        {
            Debug.WriteLine("Переход назад");
            _pageService.ChangePage(new Page1());
        }
        #endregion
        public DetailCryptoPageViewModel(PageService pageService)
        {
            _pageService = pageService;

            #region CommandRegister

            ChangePageBack = new LambdaCommand(OnChangePageBackExcecuted, CanChangePageBackExcecute);
            #endregion
        }
    }
}
