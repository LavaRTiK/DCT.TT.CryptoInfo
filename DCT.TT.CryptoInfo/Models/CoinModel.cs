using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DCT.TT.CryptoInfo.Models
{
    internal class CoinModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("rank")]
        public int Rank { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("marketCapUsd")]
        public double MarketCapUsd { get; set; }
        [JsonPropertyName("priceUsd")]
        public double PriceUsd { get; set; }
        [JsonPropertyName("changePercent24Hr")]
        public double ChangePercent24Hr { get; set; }
        [JsonPropertyName("volumeUsd24Hr")]
        public double VolumeUsd24Hr { get; set; }
    }
}
