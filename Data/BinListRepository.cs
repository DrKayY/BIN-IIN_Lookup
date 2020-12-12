using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CardDetailsGetter.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CardDetailsGetter.Data
{
    public class BinListRepository : ICardDetailsRepository
    {
        private readonly IConfiguration _configuration;
        public BinListRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CardDetailString GetCardDetails(string cardNumber)
        {
            var httpClient = new HttpClient();
            var url = $"{_configuration.GetSection("WebApis:BinList").Value}";
            httpClient.BaseAddress = new Uri(url);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = httpClient.GetAsync(cardNumber);
            var cardDetails = new CardDetailString();

            if(response.Exception == null) {
                var result = response.Result.Content.ReadAsStringAsync().Result;
                cardDetails = JsonConvert.DeserializeObject<CardDetailString>(result);
            }

            else {
                cardDetails = null;
            }

            return cardDetails;
        }

        public async Task<CardDetails> GetCardDetailsAsync(string cardNumber)
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(_configuration.GetSection("WebApis:BinList").Value);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync(cardNumber);
            CardDetails cardDetails = null;
            
            if(response.IsSuccessStatusCode) {
                var result = response.Content.ReadAsStringAsync().Result;
                cardDetails = JsonConvert.DeserializeObject<CardDetails>(result);
            }

            return cardDetails;
        }
    }
}