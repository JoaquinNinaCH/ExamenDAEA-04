using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace BackendExam.Controllers
{
    [Route("api")]
    [ApiController]
    public class TenorController : ControllerBase
    {
        [HttpGet("{valor}")]
        public async Task<IActionResult> Get(string valor) // Agrega el parámetro otroValor
        {
            // clave de API de Tenor
            string apiKey = "AIzaSyB2KNGr9BTKdbOb0bceYpz8YYJen3H9RdA";

            
            int limit = 1;

            
            using (var httpClient = new HttpClient())
            {
                
                string apiUrl = $"https://api.tenor.com/v2/search?q={valor}&key={apiKey}&limit={limit}";

                try
                {
                    // Realizar la solicitud GET a la API de Tenor
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer y procesar la respuesta JSON
                        string json = await response.Content.ReadAsStringAsync();

                        return Ok(json); // Devuelve la respuesta JSON como Ok (código 200).
                    }
                    else
                    {
                        return BadRequest("Error en la solicitud a la API de Tenor");
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error: {ex.Message}");
                }
            }
        }
    }
}