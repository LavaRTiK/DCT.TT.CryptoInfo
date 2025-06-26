using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DCT.TT.CryptoInfo.Models
{
    internal class MarketModel
    {
        [JsonProperty("exchangeId")]
        public string ExchangeId { get; set; }
        [JsonProperty("baseId")]
        public string BaseId { get; set; }
        [JsonProperty("quoteId")]
        public string QuoteId { get; set; }
        [JsonProperty("baseSymbol")]
        public string BaseSymbol { get; set; }
        [JsonProperty("quoteSymbol")]
        public string QuoteSymbol { get; set; }
        [JsonProperty("volumeUsd24Hr")]
        public double VolumeUsd24 { get; set; }
        [JsonProperty("priceUsd")]
        public double PriceUsd { get; set; }
        [JsonProperty("volumePercent")]
        public double VolumePercent { get; set; }
    }
}
