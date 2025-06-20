using System;
using System.Text.Json.Serialization;

namespace DCT.TT.CryptoInfo.Models
{
    internal class PointCoin
    {
        [JsonPropertyName("priceUsd")]
        public double PriceUsd { get; set; }
        [JsonPropertyName("time")]
        public long TimeStamp { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }
}