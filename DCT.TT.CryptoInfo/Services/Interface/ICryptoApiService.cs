using DCT.TT.CryptoInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCT.TT.CryptoInfo.Services.Interface
{
    internal interface ICryptoApiService
    {
        public Task<HistoryCoinPoint> ExcuteHistoryCoin(string id, string interval = "m30");
        public Task<List<CoinModel>> ExecuteCryptoAsync(int limitCount = 10);
        public  Task<CoinModel> ExecuteCryptoSlugId(string id);
        public Task<List<MarketModel>> GetMarket(string coinId, int limit = 5, int offset = 0);
        public Task<List<CoinModel>> GetCoinsStrSearch(string str);
    }
}
