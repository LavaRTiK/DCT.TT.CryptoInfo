using DCT.TT.CryptoInfo.Models;
using DCT.TT.CryptoInfo.ViewModels.Base;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using DCT.TT.CryptoInfo.Services.Interface;
using OxyPlot.Axes;
using OxyPlot.Legends;

namespace DCT.TT.CryptoInfo.ViewModels
{
    internal class Page1ViewModel : ViewModelBase
    {
        private readonly ICryptoApiService _serviceCryptoApiService;
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

        public Page1ViewModel(ICryptoApiService serviceCryptoApi)
        {
            //Console.WriteLine("TEST TE3ST");
            _serviceCryptoApiService = serviceCryptoApi;
            InitAsync();
            //var dataPoin = new List<PointCoin>();
            //PointCoin point1 = new PointCoin()
            //{
            //    Date = Convert.ToDateTime("2024-06-21T00:00:00.000Z"),
            //    PriceUsd = 61211.9141206542938147,
            //    TimeStamp = 1718928000000,
            //};
            //PointCoin point2 = new PointCoin()
            //{
            //    Date = Convert.ToDateTime("2024-06-22T00:00:00.000Z"),
            //    PriceUsd = 64271.1040065361808159,
            //    TimeStamp = 1718928000000,
            //};
            //PointCoin point3 = new PointCoin()
            //{
            //    Date = Convert.ToDateTime("2024-06-23T00:00:00.000Z"),
            //    PriceUsd = 69317.2628176820675963,
            //    TimeStamp = 1719014400000,
            //};
            //dataPoin.Add(point1);
            //dataPoin.Add(point2);
            //dataPoin.Add(point3);
            //CryptoDiagram1 = initModel(dataPoin);
            //CryptoDiagram2 = initModel(dataPoin);
            //CryptoDiagram3 = initModel(dataPoin);
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
            ListCrypto = await _serviceCryptoApiService.ExecuteCryptoAsync(10);
        }

        private async Task LoadDataCryptoHistoryAsync()
        {
            //Hardcode 
            CryptoDiagram1 =initModel((await _serviceCryptoApiService.ExcuteHistoryCoin(ListCrypto[0].Id)).HistoryCoin);
            NameCoinDiagram1 = ListCrypto[0].Name;
            SymbolDiagram1 = ListCrypto[0].Symbol;

            CryptoDiagram2 = initModel((await _serviceCryptoApiService.ExcuteHistoryCoin(ListCrypto[1].Id)).HistoryCoin);
            NameCoinDiagram2 = ListCrypto[1].Name;
            SymbolDiagram2 = ListCrypto[1].Symbol;

            CryptoDiagram3 = initModel((await _serviceCryptoApiService.ExcuteHistoryCoin(ListCrypto[2].Id)).HistoryCoin);
            NameCoinDiagram3 = ListCrypto[2].Name;
            SymbolDiagram3 = ListCrypto[2].Symbol;
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
                EndPosition = 0.6,
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
