using System;
using Newtonsoft.Json;

namespace DCT.TT.CryptoInfo.Models
{
    internal class PointCoin
    {
        [JsonProperty("priceUsd")]
        public double PriceUsd { get; set; }
        [JsonProperty("time")]
        public long TimeStamp { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}