﻿using DCT.TT.CryptoInfo.Infrastructure.Enums;
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
using DCT.TT.CryptoInfo.Infrastructure.Commands;
using DCT.TT.CryptoInfo.Services;
using DCT.TT.CryptoInfo.Services.Interface;
using DCT.TT.CryptoInfo.Views.Page;

namespace DCT.TT.CryptoInfo.ViewModels
{
    internal class SettingsPageViewModel : ViewModelBase
    {
        private ICryptoApiService _cryptoApiService;
        private readonly PageService _pageService;
        #region Propery

        #region CurrentApiProperty

        private string _currentApi;

        public string CurrentApi
        {
            get => _currentApi;
            set
            {
                Set(ref _currentApi, value);
                Debug.WriteLine("update currentApi");
                UpdateToken();
            }
        }

        #endregion
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
            _pageService.ChangePage(new Page1());
        }

        #endregion

        #endregion

        public SettingsPageViewModel(PageService pageService,ICryptoApiService cryptoApiService)
        {
            _pageService = pageService;
            _cryptoApiService = cryptoApiService;
            CurrentApi= _cryptoApiService.GetToken();
            Localizations = App.Languages;
            //private dont update ProprtyChange
            _itemSelectedLocalization = CheckCurrentCulture();
            #region Commands

            ChangePageBack = new LambdaCommand(OnChangePageBackExcecuted, CanChangePageBackExcecute);

            #endregion
        }

        private void UpdateToken()
        {
            if (!string.IsNullOrWhiteSpace(CurrentApi))
            {
                _cryptoApiService.SetToken(CurrentApi);
            }
            else
            {
                return;
            }
        }
        private CultureInfo CheckCurrentCulture()
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentUICulture;
            Debug.WriteLine(culture.Name);
            return culture;
        }

    }
}
