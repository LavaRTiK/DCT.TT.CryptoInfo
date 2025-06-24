using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DCT.TT.CryptoInfo.Models
{
    internal class ParseDataJson
    {
        [JsonProperty("data")]
        public List<CoinModel> listCoin { get; set; }
        [JsonProperty("timestamp")]
        public long TimeStamp { get; set; }
    }
}
