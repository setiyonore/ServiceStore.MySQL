using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using ServiceStore.MySQL.DataTransferObejct;

namespace ServiceStore.MySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceController : ControllerBase
    {
        [HttpGet("getProvince")]
        public async Task<IActionResult> GetProvince()
        {
            var _client = new RestClient("https://api.rajaongkir.com/starter");
            var request = new RestRequest("/province");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("key", "81597abf054554a561654e6d89fb5799");
            var response = await _client.ExecuteGetAsync(request);
            var provinceList = JsonConvert.DeserializeObject<Province>(response.Content);
            return Ok(provinceList);

        }

        [HttpGet("getCity")]
        public async Task<IActionResult> GetCity(string province)
        {
            var _client = new RestClient("https://api.rajaongkir.com/starter");
            var request = new RestRequest("/city?id="+"&province="+province);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("key", "81597abf054554a561654e6d89fb5799");
            var response = await _client.ExecuteGetAsync(request);
            var cityList = JsonConvert.DeserializeObject<City>(response.Content);
            return Ok(cityList);
        }

    }
}
