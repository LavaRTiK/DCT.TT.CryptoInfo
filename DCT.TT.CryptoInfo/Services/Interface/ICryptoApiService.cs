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
    }
}
