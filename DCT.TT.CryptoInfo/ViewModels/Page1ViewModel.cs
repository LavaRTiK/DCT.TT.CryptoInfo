using DCT.TT.CryptoInfo.Infrastructure.Commands;
using DCT.TT.CryptoInfo.Models;
using DCT.TT.CryptoInfo.Services;
using DCT.TT.CryptoInfo.Services.Interface;
using DCT.TT.CryptoInfo.ViewModels.Base;
using DCT.TT.CryptoInfo.Views.Page;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Navigation;

namespace DCT.TT.CryptoInfo.ViewModels
{
    [MarkupExtensionReturnType(typeof(Page1ViewModel))]
    internal class Page1ViewModel : ViewModelBase
    {
        private readonly ICryptoApiService _serviceCryptoApiService;
        private readonly PageService _pageService;
        #region Property

        #region ListTestObject

        private HistoryCoinPoint _historyCoin;
        public HistoryCoinPoint HistoryCoin
        {
            get => _historyCoin;
            set
            {
                Set(ref _historyCoin, value);
            }
        }
        #endregion

        #region TestData

        private IEnumerable<PointCoin> _testDataPoints;

        private IEnumerable<PointCoin> TestDataPoints
        {
            get => _testDataPoints;
            set => Set(ref _testDataPoints, value);
        }

        #endregion

        #region ListCrypto
        //dont update dimamic  ObservableCollection 
        private List<CoinModel> _listCrypto;
        public List<CoinModel> ListCrypto
        {
            get => _listCrypto;
            set
            {
                Set(ref _listCrypto, value);
            }
        }
        #endregion
        #region Diagram1
        private PlotModel _cryptoDiagram1;
        public PlotModel CryptoDiagram1
        {
            get => _cryptoDiagram1;
            set
            {
                Set(ref _cryptoDiagram1, value);
            }
        }
        #endregion
        #region NameDiagram1
        private string _nameCoinDiagram1;
        public string NameCoinDiagram1
        {
            get => _nameCoinDiagram1;
            set
            {
                Set(ref _nameCoinDiagram1, value);
            }
        }
        #endregion
        #region SymbolDiagram1
        private string _symbolDiagram1;
        public string SymbolDiagram1
        {
            get => _symbolDiagram1;
            set
            {
                Set(ref _symbolDiagram1, value);
            }
        }
        #endregion
        #region Diagram2
        private PlotModel _cryptoDiagram2;
        public PlotModel CryptoDiagram2
        {
            get => _cryptoDiagram2;
            set
            {
                Set(ref _cryptoDiagram2, value);
            }
        }
        #endregion
        #region NameDiageam2
        private string _nameCoinDiagram2;
        public string NameCoinDiagram2
        {
            get => _nameCoinDiagram2;
            set
            {
                Set(ref _nameCoinDiagram2, value);
            }
        }
        #endregion
        #region SymbolDiagram2
        private string _symbolDiagram2;
        public string SymbolDiagram2
        {
            get => _symbolDiagram2;
            set
            {
                Set(ref _symbolDiagram2, value);
            }
        }
        #endregion
        #region Diagram3
        private PlotModel _cryptoDiagram3;
        public PlotModel CryptoDiagram3
        {
            get => _cryptoDiagram3;
            set
            {
                Set(ref _cryptoDiagram3, value);
            }
        }
        #endregion
        #region NameDiagram3



        private string _nameCoinDiagram3;
        public string NameCoinDiagram3
        {
            get => _nameCoinDiagram3;
            set
            {
                Set(ref _nameCoinDiagram3, value);
            }
        }
        #endregion

        #region SymbolDiagram3
        private string _symbolDiagram3;
        public string SymbolDiagram3
        {
            get => _symbolDiagram3;
            set
            {
                Set(ref _symbolDiagram3, value);
            }
        }
        #endregion
        #endregion

        #region Command

        #region SelecetCryptoCommand

        public ICommand SelectCryptoCommand { get; }

        private bool CanSelectCryptoCommandExecute(object p) => true;
        private void OnSelectCryptoCommandExecuted(object p)
        {
            Debug.WriteLine("псеводо сохранения команды c id:" + p.ToString());
            _pageService.ChangePage(new DetailCryptoPage());
            Debug.WriteLine("сменил страницу");
        }
        #endregion

        #endregion

        public Page1ViewModel(ICryptoApiService serviceCryptoApi, PageService pageService)
        {

            _serviceCryptoApiService = serviceCryptoApi;
            _pageService = pageService;
            #region Command

            SelectCryptoCommand = new LambdaCommand(OnSelectCryptoCommandExecuted, CanSelectCryptoCommandExecute);

            #endregion
            InitAsync();
        }

        private void UpdateDiagram()
        {
            //timer update 5 second //requst limit 
        }

        private async void InitAsync()
        {
            await LoadDataCryptoAsync();
            await LoadDataCryptoHistoryAsync();
        }
        private async Task LoadDataCryptoAsync()
        {
            if (await _serviceCryptoApiService.ExecuteCryptoAsync(10) is { } data)
                ListCrypto = data;
            else if (Debugger.IsAttached)
            {
                Debug.WriteLine("Заисал мог поект для listCoin");
                //test object
                List<CoinModel> listCoin = new List<CoinModel>();
                listCoin.Add(new CoinModel
                {
                    Id = "bitcoin",
                    Rank = "1",
                    Symbol = "BTC",
                    Name = "BitCoin",
                    MarketCapUsd = 2065776649754.4532176367632261,
                    PriceUsd = 103898.4932614066056327,
                    ChangePercent24Hr = 4.6321745238798559,
                    VolumeUsd24Hr = 101251.5781941297998463
                });
                listCoin.Add(new CoinModel
                {
                    Id = "ethereum",
                    Rank = "2",
                    Symbol = "ETH",
                    Name = "Ethereum",
                    MarketCapUsd = 2065776649754.4532176367632261,
                    PriceUsd = 103898.4932614066056327,
                    ChangePercent24Hr = 4.6321745238798559,
                    VolumeUsd24Hr = 101251.5781941297998463
                });
                listCoin.Add(new CoinModel
                {
                    Id = "xrp",
                    Rank = "2",
                    Symbol = "XRP",
                    Name = "XRP",
                    MarketCapUsd = 2065776649754.4532176367632261,
                    PriceUsd = 103898.4932614066056327,
                    ChangePercent24Hr = 4.6321745238798559,
                    VolumeUsd24Hr = 101251.5781941297998463
                });
                ListCrypto = listCoin;

            }
        }
        private async Task LoadDataCryptoHistoryAsync()
        {
            //Hardcode 
            if (ListCrypto is null)
            {
                return;
            }
            var result1 = await _serviceCryptoApiService.ExcuteHistoryCoin(ListCrypto[0].Id);
            if (result1 != null)
            {
                var dataCoin1 = result1.HistoryCoin;
                if (dataCoin1 != null)
                {
                    CryptoDiagram1 = initModel(dataCoin1);
                    NameCoinDiagram1 = ListCrypto[0].Name;
                    SymbolDiagram1 = ListCrypto[0].Symbol;
                }
            }
            var result2 = await _serviceCryptoApiService.ExcuteHistoryCoin(ListCrypto[1].Id);
            if (result2 != null)
            {
                var dataCoin = result2.HistoryCoin;
                if (dataCoin != null)
                {
                    CryptoDiagram2 = initModel(dataCoin);
                    NameCoinDiagram2 = ListCrypto[1].Name;
                    SymbolDiagram2 = ListCrypto[1].Symbol;
                }
            }
            var result3 = await _serviceCryptoApiService.ExcuteHistoryCoin(ListCrypto[2].Id);
            if (result3 != null)
            {
                var dataCoin = result3.HistoryCoin;
                if (dataCoin != null)
                {
                    CryptoDiagram3 = initModel(dataCoin);
                    NameCoinDiagram3 = ListCrypto[2].Name;
                    SymbolDiagram3 = ListCrypto[2].Symbol;
                }
            }
            //test object
            if (CryptoDiagram1 is null && CryptoDiagram2 is null && CryptoDiagram3 is null)
            {
                var dataPoin = new List<PointCoin>();
                PointCoin point1 = new PointCoin()
                {
                    Date = Convert.ToDateTime("2024-06-21T00:00:00.000Z"),
                    PriceUsd = 61211.9141206542938147,
                    TimeStamp = 1718928000000,
                };
                PointCoin point2 = new PointCoin()
                {
                    Date = Convert.ToDateTime("2024-06-22T00:00:00.000Z"),
                    PriceUsd = 64271.1040065361808159,
                    TimeStamp = 1718928000000,
                };
                PointCoin point3 = new PointCoin()
                {
                    Date = Convert.ToDateTime("2024-06-23T00:00:00.000Z"),
                    PriceUsd = 69317.2628176820675963,
                    TimeStamp = 1719014400000,
                };
                dataPoin.Add(point1);
                dataPoin.Add(point2);
                dataPoin.Add(point3);
                CryptoDiagram1 = initModel(dataPoin);
                CryptoDiagram2 = initModel(dataPoin);
                CryptoDiagram3 = initModel(dataPoin);
            }
        }
        private PlotModel initModel(List<PointCoin> dataPoin)
        {
            var min = dataPoin.Min(p => p.PriceUsd);
            var max = dataPoin.Max(p => p.PriceUsd);
            var model = new PlotModel
            {
                IsLegendVisible = false,
                Background = OxyColors.Transparent,
                PlotAreaBackground = OxyColors.Transparent,
                PlotAreaBorderThickness = new OxyThickness(0),

            };

            model.Axes.Add(new LinearAxis()
            {
                //Price
                Minimum = min - (min * 0.2),
                //Maximum = max + 50,
                Position = AxisPosition.Left,
                Title = "",
                IsZoomEnabled = false,
                IsPanEnabled = false,
                IsAxisVisible = false,
                StartPosition = 0,
                EndPosition = 0.5,
            });
            model.Axes.Add(new DateTimeAxis
            {
                IsZoomEnabled = false,
                IsPanEnabled = false,
                IsAxisVisible = false,
                Position = AxisPosition.Bottom,
                Title = ""
            });
            var lineSeries = new AreaSeries()
            {
                Color = OxyColor.FromAColor(255, OxyColors.Aqua),
                Fill = OxyColor.FromAColor(40, OxyColors.Aqua),
                //Color2 = OxyColor.FromAColor(50, OxyColors.Aqua),
                StrokeThickness = 2,
                MarkerType = MarkerType.None,
            };
            foreach (var item in dataPoin)
            {
                lineSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(item.Date), item.PriceUsd));
                lineSeries.Points2.Add(new DataPoint(DateTimeAxis.ToDouble(item.Date), 0));
            }
            model.Series.Add(lineSeries);
            return model;
        }

    }
}
