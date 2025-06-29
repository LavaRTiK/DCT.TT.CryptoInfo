﻿using DCT.TT.CryptoInfo.Models;
using DCT.TT.CryptoInfo.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Newtonsoft.Json;

namespace DCT.TT.CryptoInfo.Services
{
    internal class CryptoApiService : ICryptoApiService
    {
        private string _token = "";
        private HttpClient _httpClient;

        public CryptoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://rest.coincap.io/v3/");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        }

        public string GetToken()
        {
            return _token;
        }
        public void SetToken(string token)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                _token = token;
            }
        }
        public ParseDataJson GetFullDataWithTimeStamp()
        {
            return null;
        }

        public async Task<HistoryCoinPoint> ExcuteHistoryCoin(string id, string interval = "m30")
        {
            try
            {
                return JsonConvert.DeserializeObject<HistoryCoinPoint>(
                    await _httpClient.GetStringAsync($"/v3/assets/{id}/history?interval={interval}"));
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<CoinModel>> ExecuteCryptoAsync(int limitCount = 10)
        {
            //using HttpResponseMessage renponse = await _httpClient.GetAsync("/v3/assets");
            //renponse.EnsureSuccessStatusCode();
            //string requstBody = await renponse.Content.ReadAsStringAsync();
            //List<CoinModel> coinList = JsonSerializer.Deserialize<ParseDataJson>(requstBody).listCoin;
            //+читабильность оу ейс
            try
            {
                return JsonConvert.DeserializeObject<ParseDataJson>
                        (await _httpClient.GetStringAsync($"/v3/assets?limit{limitCount}"))
                    .listCoin;
            }
            catch
            {
                return null;
            }
            //return JsonSerializer.Deserialize<ParseDataJson>(await _httpClient.GetStringAsync("/v3/assets")).listCoin;
        }

        public async Task<CoinModel> ExecuteCryptoSlugId(string id)
        {
            if (id is null || string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            try
            {
                return JsonConvert
                    .DeserializeObject<OnlyOneCoinData>(await _httpClient.GetStringAsync($"/v3/assets/{id}")).CoinModel;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<MarketModel>> GetMarket(string coinId, int limit = 5, int offset = 0)
        {
            try
            {
                var respone =
                    await _httpClient.GetStringAsync($"/v3/assets/{coinId}/market?limit={limit}&offset={offset}");
                List<MarketModel> marketModels = JsonConvert.DeserializeObject<DataMarket>(respone).MarketList;
                return marketModels;

            }
            catch
            {
                return new List<MarketModel>();
            }
        }
        public async Task<List<CoinModel>> GetCoinsStrSearch(string str)
        {
            try
            {
                var respons = await _httpClient.GetStringAsync($"/v3/assets?search={str}&limit=5");
                List<CoinModel> listCoin = JsonConvert.DeserializeObject<ParseDataJson>(respons).listCoin;
                return listCoin;
            }
            catch
            {
                return new List<CoinModel>();
            }
        }

        public async Task<bool> Ping()
        {
            try
            {
                using var renponse = await _httpClient.GetAsync("/v3/assets");
                renponse.EnsureSuccessStatusCode(); 
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
