using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCT.TT.CryptoInfo.Models
{
    internal class DataMarket
    {
        [JsonProperty("data")]
        public List<MarketModel> MarketList { get; set; }
    }
}
