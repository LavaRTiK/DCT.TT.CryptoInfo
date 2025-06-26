using DCT.TT.CryptoInfo.Infrastructure.Commands;
using DCT.TT.CryptoInfo.Models;
using DCT.TT.CryptoInfo.Services;
using DCT.TT.CryptoInfo.ViewModels.Base;
using DCT.TT.CryptoInfo.Views.Page;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Markup;
using DCT.TT.CryptoInfo.Services.Interface;

namespace DCT.TT.CryptoInfo.ViewModels
{
    [MarkupExtensionReturnType(typeof(DetailCryptoPageViewModel))]
    internal class DetailCryptoPageViewModel : ViewModelBase
    {
        private GlobalSettingsService _gb;
        private PageService _pageService;
        private readonly ICryptoApiService _cryptoApiService;
        private readonly string _currentId;
        private int _tabelPageOffset = 0;
        private string _intervalSet = "m30";
        #region Property

        #region ListMarkets
        private List<MarketModel> _listMarketModels;
        public List<MarketModel> ListMarketModels
        {
            get => _listMarketModels;
            set
            {
                Set(ref _listMarketModels, value);
            }
        }
        #endregion
        #region Price
        private double _priceCoin;
        public double PriceCoin
        {
            get => _priceCoin;
            set
            {
                Set(ref _priceCoin, value);
            }
        }
        #endregion
        #region ChangePercent24Hr
        private double _changePercent;
        public double ChangePercent
        {
            get => _changePercent;
            set
            {
                Set(ref _changePercent, value);
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
        #region  CryptoDiagram1
        private PlotModel _cryptoDiagram1;

        public PlotModel CryptoDiagram1
        {
            get => _cryptoDiagram1;
            set { Set(ref _cryptoDiagram1, value); }
        }
        #endregion

        #endregion

        #region Command

        #region ChangeOffset
        public ICommand ChangeOffsetPageCommand { get; }
        private bool CanChangeOffsetPageCommandExcecute(object p)
        {
            if (_tabelPageOffset + Convert.ToInt32(p) < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private async void OnChangeOffsetPageCommandExcecuted(object p)
        {
            _tabelPageOffset += Convert.ToInt32(p);
            Debug.WriteLine(_tabelPageOffset+"<-- current_TABBELPAGEOFFFSET");
            await LoadMarket();

        }

        #endregion
        #region ChangeTimeDiagramCommand

        public ICommand ChangeTimeDiagramCommand { get; }

        private bool CanChangeTimeDiagramCommandExcecute(object p) => true;
        private async void OnChangeTimeDiagramCommandExcecuted(object p)
        {
            _intervalSet = p.ToString();
            CryptoDiagram1 = null;
            await LoadDataCryptoHistoryAsync();
        }
        #endregion
        #region ChangePageBackCommand
        public ICommand ChangePageBackCommand { get; }

        private bool CanChangePageBackExcecute(object p) => true;
        private void OnChangePageBackExcecuted(object p)
        {
            Debug.WriteLine("Переход назад");
            _gb.CurrentSelectedId = null;
            _pageService.ChangePage(new Page1());
        }
        #endregion
        #endregion
        public DetailCryptoPageViewModel(PageService pageService,GlobalSettingsService gb,ICryptoApiService cryptoApiService)
        {
            _cryptoApiService = cryptoApiService;
            _gb = gb; 
            _currentId = gb.CurrentSelectedId;
            _pageService = pageService;
            var test = 5;
            test += -5;
            Debug.WriteLine(test);
            #region CommandRegister

            ChangeOffsetPageCommand =
                new LambdaCommand(OnChangeOffsetPageCommandExcecuted, CanChangeOffsetPageCommandExcecute);
            ChangeTimeDiagramCommand =
                new LambdaCommand(OnChangeTimeDiagramCommandExcecuted, CanChangeTimeDiagramCommandExcecute);
            ChangePageBackCommand = new LambdaCommand(OnChangePageBackExcecuted, CanChangePageBackExcecute);
            #endregion
            //Mok object
            //сделать загрзку маркетов
            //сделать страницы
            //сделать команды вперед назад для offset маркет 

            InitAsync();

        }
        private async void InitAsync()
        {
            await LoadDataCrypto();
            await LoadDataCryptoHistoryAsync();
            await LoadMarket();
        }

        private async Task LoadMarket()
        {
            var  result = await _cryptoApiService.GetMarket(_currentId, limit: 5, _tabelPageOffset);
            if (result.Count == 0)
            {
                result.Add(new MarketModel
                {
                    ExchangeId = "Binance",
                    BaseId = "bitcoin",
                    QuoteId = "first-digital-usd",
                    BaseSymbol = "BTC",
                    QuoteSymbol = "FDUSD",
                    VolumeUsd24 = 2456986658.1635031000000000,
                    PriceUsd = 108084.8100000000000000,
                    VolumePercent = 17.1285198419989211
                });
                result.Add(new MarketModel
                {
                    ExchangeId = "Binance",
                    BaseId = "bitcoin",
                    QuoteId = "tether",
                    BaseSymbol = "BTC",
                    QuoteSymbol = "USDT",
                    VolumeUsd24 = 1726909990.1909699276160000,
                    PriceUsd = 107931.9624864000000000,
                    VolumePercent = 12.0388981088084498
                });
                result.Add(new MarketModel
                {
                    ExchangeId = "BYBIT",
                    BaseId = "bitcoin",
                    QuoteId = "tether",
                    BaseSymbol = "BTC",
                    QuoteSymbol = "USDT",
                    VolumeUsd24 = 908510306.0295488416320000,
                    PriceUsd = 107928.6809120000000000,
                    VolumePercent = 6.3335455045243005
                });
            }
            Debug.WriteLine("Test update listMaraket");
            ListMarketModels = result;

        }

        private async Task LoadDataCrypto()
        {
            CoinModel coin = await _cryptoApiService.ExecuteCryptoSlugId(_currentId);
            if (coin is null)
            {
                NameCoinDiagram1 = "BitCoin";
                SymbolDiagram1 = "BTC";
                PriceCoin = 42000.20;
                return;
            }

            NameCoinDiagram1 = coin.Name;
            SymbolDiagram1 = coin.Symbol;
            PriceCoin = coin.PriceUsd;


        }

        private async Task LoadDataCryptoHistoryAsync()
        {
            HistoryCoinPoint result;
            try
            {
                result = await _cryptoApiService.ExcuteHistoryCoin(_currentId,_intervalSet);
                if (result != null)
                {
                    CryptoDiagram1 = initModel(result.HistoryCoin);
                }
            }
            catch
            {
                Debug.WriteLine("error запрос");
            }
            //Hardcode 
            if (CryptoDiagram1 is null)
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
            }
        }
        private PlotModel initModel(List<PointCoin> dataPoin)
        {
            var min = dataPoin.Min(p => p.PriceUsd);
            var max = dataPoin.Max(p => p.PriceUsd);
            var model = new PlotModel
            {
                IsLegendVisible = true,
                Background = OxyColors.Transparent,
                TextColor = OxyColors.White,
                PlotAreaBackground = OxyColors.Transparent,
                PlotAreaBorderThickness = new OxyThickness(0),

            };

            model.Axes.Add(new LinearAxis()
            {
                //Price
                Minimum = min - (min * 0.2),
                //Maximum = max + 50,
                Position = AxisPosition.Right,
                Title = "",
                IsZoomEnabled = false,
                IsPanEnabled = false,
                IsAxisVisible = true,
                StartPosition = 0,
                EndPosition = 0.5,
            });
            model.Axes.Add(new DateTimeAxis
            {
                IsZoomEnabled = false,
                IsPanEnabled = false,
                IsAxisVisible = true,
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
