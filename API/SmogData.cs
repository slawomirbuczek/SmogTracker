using SmogTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmogTracker.API
{
    public interface ISmogData
    {
        DataModel DataModel { get; }

        void RefreshData();
    }

    public class SmogData : ISmogData
    {
        private readonly IHttpClientFactory _clientFactory;
        public DataModel DataModel { get; set; }

        public SmogData(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            DataModel = GetDataFromAirly().Result;
        }

        public void RefreshData()
        {
            this.DataModel = GetDataFromAirly().Result;
        }

        private async Task<DataModel> GetDataFromAirly()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "https://airapi.airly.eu/v2/measurements/point?lat=50.07513096&lng=19.9976790667");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("apikey", "");
            request.Headers.Add("Accept-Language", "pl");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            string usesLeft = "";

            if (response.Headers.TryGetValues("X-RateLimit-Remaining-day", out IEnumerable<string> headerValues))
            {
                usesLeft = headerValues.FirstOrDefault();
            }

            var data = await JsonSerializer.DeserializeAsync<DataModel>(responseStream);

            data.usesLeft = usesLeft;

            data.timeOfMeasurement = DateTime.Now.ToString("HH:mm");

            Array.Reverse(data.history);

            return data;
        }

    }
}
