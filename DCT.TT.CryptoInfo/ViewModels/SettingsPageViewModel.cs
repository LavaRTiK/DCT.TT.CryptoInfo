using DCT.TT.CryptoInfo.Infrastructure.Enums;
using DCT.TT.CryptoInfo.Models;
using DCT.TT.CryptoInfo.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using DCT.TT.CryptoInfo.Services;

namespace DCT.TT.CryptoInfo.ViewModels
{
    internal class SettingsPageViewModel : ViewModelBase
    {
        private readonly PageService _pageService;
        #region Propery

        #region LocalizationList
        private List<CultureInfo> _localizations;
        public List<CultureInfo> Localizations
        {
            get => _localizations;
            set
            {
                Set(ref _localizations, value);
            }
        }
        #endregion

        #region ItemSelectedLocalization
        private CultureInfo _itemSelectedLocalization;
        public CultureInfo ItemSelectedLocalization
        {
            get => _itemSelectedLocalization;
            set
            {
                if (Set(ref _itemSelectedLocalization, value))
                {
                    App.Language = value;
                    Debug.WriteLine("Сменил культуру");
                }
            }
        }
        #endregion
        #endregion

        #region Command

        #region ChangePage

        public ICommand ChangePageBack { get; }
        private bool CanChangePageBackExcecute(object p) => true;

        private void OnChangePageBackExcecuted(object p)
        {
            _pageService.ChangePage(new Page());
        }

        #endregion


        #endregion

        public SettingsPageViewModel(PageService pageService)
        {
            _pageService = pageService;
            Localizations = App.Languages;
            //private dont update ProprtyChange
            _itemSelectedLocalization = CheckCurrentCulture();
        }
        public CultureInfo CheckCurrentCulture()
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentUICulture;
            Debug.WriteLine(culture.Name);
            return culture;
        }

    }
}
