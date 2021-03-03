using System;
using System.Dynamic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PeriodicTableService
{
    public class PeriodicTableService
    {
        private const string JsonUrl = "https://raw.githubusercontent.com/Bowserinator/Periodic-Table-JSON/master/PeriodicTableJSON.json";
        private bool _downloadedData;
        private readonly HttpClient _client;

        public PeriodicTable PeriodicTable { get; private set; }

        internal PeriodicTableService(HttpClient client)
        {
            _downloadedData = false;
            _client = client;
        }

        public async Task FillCacheAsync()
        {
            if (_downloadedData)
                return;

            var response = await _client.GetAsync(JsonUrl);
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            PeriodicTable = JsonConvert.DeserializeObject<PeriodicTable>(jsonString);
        }

        public static async Task<PeriodicTableService> Create(HttpClient client)
        {
            var service = new PeriodicTableService(client);
            await service.FillCacheAsync();
            return service;
        }
    }
}
