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

        private PeriodicTable _periodicTable { get; set; }

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
            _periodicTable = JsonConvert.DeserializeObject<PeriodicTable>(jsonString);
        }

        public PeriodicTable GetPeriodicTable()
        {
            ThrowIfNotDownloaded();

            return _periodicTable;
        }

        private void ThrowIfNotDownloaded()
        {
            if (!_downloadedData)
                throw new Exception("Periodic Table data not downloaded.  Try calling FillCacheAsync or use the Create method.");
        }

        public static async Task<PeriodicTableService> Create(HttpClient client)
        {
            var service = new PeriodicTableService(client);
            await service.FillCacheAsync();
            return service;
        }
    }
}
