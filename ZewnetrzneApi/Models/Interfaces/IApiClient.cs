using System.Threading.Tasks;

namespace ZewnetrzneApi.Models.Interfaces
{
    //tworzymy interfejs naszego ApiClient aby moduly wykorzystujace go wiedzialy co mozna z nim robic
    public interface IApiClient
    {
        Task<WeatherApiModel> GetCity(string cityName);
    }
}
