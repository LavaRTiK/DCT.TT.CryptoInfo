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
using OxyPlot.Axes;
using OxyPlot.Legends;

namespace DCT.TT.CryptoInfo.ViewModels
{
    internal class Page1ViewModel : ViewModelBase
    {
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
        #endregion

        public PlotModel CryptoDiagram1 { get; private set; }
        public PlotModel CryptoDiagram2 { get; private set; }
        public PlotModel CryptoDiagram3 { get; private set; }
        public Page1ViewModel()
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

        private void UpdateDiagram()
        {
            //timer update 5 second 
        }
        private PlotModel initModel(List<PointCoin> dataPoin)
        {
            var min = dataPoin.Min(p => p.PriceUsd);
            var max = dataPoin.Max(p => p.PriceUsd);
            var model = new PlotModel
            {
                IsLegendVisible = false,
                PlotAreaBorderThickness = new OxyThickness(1.5),
                Background = OxyColors.Transparent,
                PlotAreaBackground = OxyColors.Transparent,
                PlotAreaBorderColor = OxyColors.DarkSlateGray,
                
            };

            model.Axes.Add(new LinearAxis()
            {
                //Price
                Minimum = min - (min * 0.2),
                Maximum = max + 50,
                Position = AxisPosition.Left,
                Title = "",
                IsZoomEnabled = false,
                IsPanEnabled = false,
                IsAxisVisible = false,
                StartPosition = 0,
                EndPosition = 0.7,
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
