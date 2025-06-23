using DCT.TT.CryptoInfo.Models;
using DCT.TT.CryptoInfo.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace DCT.TT.CryptoInfo.Services
{
    internal class CryptoApiService : ICryptoApiService
    {
        private string _token = "59fc2fa78469cf29f68fb8a39cba808611f813b87a2a652d69491a6742b3f2bb";
        private HttpClient _httpClient;

        private CryptoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://rest.coincap.io/v3/");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        }
        public ParseDataJson GetFullDataWithTimeStamp()
        {
            return null;
        }

        public async Task<List<CoinModel>> ExecuteCryptoAsync(int limitCount = 10)
        {
            //using HttpResponseMessage renponse = await _httpClient.GetAsync("/v3/assets");
            //renponse.EnsureSuccessStatusCode();
            //string requstBody = await renponse.Content.ReadAsStringAsync();
            //List<CoinModel> coinList = JsonSerializer.Deserialize<ParseDataJson>(requstBody).listCoin;
            //+читабильность оу ейс
            return JsonSerializer.Deserialize<ParseDataJson>(await _httpClient.GetStringAsync("/v3/assets")).listCoin;
        }
    }
}
