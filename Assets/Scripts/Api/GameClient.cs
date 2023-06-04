using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Api
{
    public class GameClient
    {
        private readonly string _baseUri;

        public GameClient(string baseUri)
        {
            _baseUri = baseUri;
        }

        public async Task<StartGameResponse> StartGame(StartGameRequest request)
        {
            using var client = new HttpClient();
            
            var uri = new Uri($"{_baseUri}/api/start");
            var body = new StringContent(JsonUtility.ToJson(request), Encoding.UTF8);
            
            var response = await client.PostAsync(uri, body);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonUtility.FromJson<StartGameResponse>(content);
            throw new ApiException(response.StatusCode, content);
        }

        public async Task EndGame(EndGameRequest request)
        {
            using var client = new HttpClient();
            
            var uri = new Uri($"{_baseUri}/api/finishsession");
            var body = new StringContent(JsonUtility.ToJson(request), Encoding.UTF8);

            var response = await client.PostAsync(uri, body);

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) throw new ApiException(response.StatusCode, content);
        }
    }
}