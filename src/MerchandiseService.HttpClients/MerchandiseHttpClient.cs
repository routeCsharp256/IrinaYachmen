using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpModels;

namespace MerchandiseService.HttpClients
{
    
        public interface IMerchandiseHttpClient
        {
            Task<List<RequestMerchandiseResponse>> GetInformationAboutIssueOfMerch(CancellationToken token);
            Task RequestMerch(long id, CancellationToken token);
        }

        public class MerchandiseHttpClient : IMerchandiseHttpClient
        {
            private readonly HttpClient _httpClient;

            public MerchandiseHttpClient(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            public async Task<List<RequestMerchandiseResponse>> GetInformationAboutIssueOfMerch(CancellationToken token)
            {
                using var response = await _httpClient.GetAsync("api/merch", token);
                var body = await response.Content.ReadAsStringAsync(token);
                return JsonSerializer.Deserialize<List<RequestMerchandiseResponse>>(body);
            }

            public async Task RequestMerch(long id, CancellationToken token)
            {
                using var response = await _httpClient.GetAsync($"api/merch/{id}", token);
                var body = await response.Content.ReadAsStringAsync(token);
                return;
            }
        }
    
}