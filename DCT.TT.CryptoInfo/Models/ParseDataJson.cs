using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DCT.TT.CryptoInfo.Models
{
    internal class ParseDataJson
    {
        [JsonPropertyName("data")]
        public List<CoinModel> listCoin { get; set; }
        [JsonPropertyName("timestamp")]
        public int TimeStamp { get; set; }
    }
}
