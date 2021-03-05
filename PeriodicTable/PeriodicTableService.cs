using System;
using System.Dynamic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Periodic.Models;

namespace Periodic.Services
{
    public sealed class PeriodicTableService
    {
        private const string JsonUrl = "https://raw.githubusercontent.com/Bowserinator/Periodic-Table-JSON/master/PeriodicTableJSON.json";
        private bool _downloadedData;
        private readonly HttpClient _client;

        private PeriodicTable _periodicTable { get; set; }

        public PeriodicTableService(HttpClient client)
        {
            _downloadedData = false;
            _client = client;
        }

        public async Task<PeriodicTable> GetPeriodicTableAsync(bool createLookups = true)
        {
            await EnsureFilledCacheAsync(createLookups);

            return _periodicTable;
        }

        private Task EnsureFilledCacheAsync(bool createLookups)
        {
            if (!_downloadedData)
                return FillCacheAsync(createLookups);

            return Task.CompletedTask;
        }

        private async Task FillCacheAsync(bool createLookups)
        {
            var response = await _client.GetAsync(JsonUrl);
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();

            if (createLookups)
                _periodicTable = JsonConvert.DeserializeObject<IndexedPeriodicTable>(jsonString);
            else
                _periodicTable = JsonConvert.DeserializeObject<PeriodicTable>(jsonString);

            if (_periodicTable is null)
                throw new Exception("Periodic Table data could not be loaded");

            _downloadedData = true;
        }
    }
}
