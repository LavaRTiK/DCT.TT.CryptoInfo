using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DCT.TT.CryptoInfo.Models
{
    internal class HistoryCoinPoint
    {
        [JsonPropertyName("data")]
        public List<PointCoin> HistoryCoin { get; set; }
    }
}
