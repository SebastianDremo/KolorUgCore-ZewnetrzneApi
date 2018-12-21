using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ZewnetrzneApi.Models.Interfaces;

namespace ZewnetrzneApi.Models
{
    public class ApiClient : IApiClient
    {
        public async Task<WeatherApiModel> GetCity(string cityName)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org");
                var response = await client.GetAsync($"data/2.5/weather?q={cityName}&appid=cd7bcb53240a0ad4f16e97abefa6d8e6");
                response.EnsureSuccessStatusCode();

                string stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherApiModel>(stringResult);

                
            }
        }
    }
}
