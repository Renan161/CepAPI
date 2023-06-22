using System.Net.Http;
using System.Threading.Tasks;
using CepAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeuProjetoCep.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CepController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> Get(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var cepResult = JsonConvert.DeserializeObject<CepModel>(content);
            return Ok(cepResult);
        }
    }
}
