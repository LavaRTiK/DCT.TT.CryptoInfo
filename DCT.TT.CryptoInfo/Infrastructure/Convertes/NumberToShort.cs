using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DCT.TT.CryptoInfo.Infrastructure.Convertes
{
    internal class NumberToShort : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;
            if (value is double numberValue)
            {
                return ParseNumberShort(numberValue);
            }
            return value?.ToString() ?? string.Empty;
        }

        private string ParseNumberShort(double numberValue)
        {
            if (numberValue > 1_000_000_000_000)
                return $"{numberValue / 1_000_000_000_000:F1}T";
            if (numberValue > 1_000_000_000)
                return $"{numberValue / 1_000_000_000:F1}B";
            if (numberValue > 1_000_000)
                return $"{numberValue / 1_000_000:F1}M";
            if (numberValue > 1_000)
                return $"{numberValue / 1000:F1}K";
            return numberValue.ToString("F0");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
