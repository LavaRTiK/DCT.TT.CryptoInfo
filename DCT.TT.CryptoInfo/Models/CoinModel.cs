using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DCT.TT.CryptoInfo.Models
{
    internal class CoinModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("rank")]
        public string Rank { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("marketCapUsd")]
        public double MarketCapUsd { get; set; }
        [JsonProperty("priceUsd")]
        public double PriceUsd { get; set; }
        [JsonProperty("changePercent24Hr")]
        public double ChangePercent24Hr { get; set; }
        [JsonProperty("volumeUsd24Hr")]
        public double VolumeUsd24Hr { get; set; }
    }
}
