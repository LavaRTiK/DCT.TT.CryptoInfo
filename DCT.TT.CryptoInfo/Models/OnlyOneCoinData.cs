using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DCT.TT.CryptoInfo.Models
{
    internal class OnlyOneCoinData
    {
        [JsonProperty("data")]
        public CoinModel CoinModel { get; set; }
    }
}
