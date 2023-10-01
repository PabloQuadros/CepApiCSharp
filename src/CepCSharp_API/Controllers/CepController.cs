using CepCSharp_API.Entities.Records;
using CepCSharp_API.Servicies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CepCSharp_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : Controller
    {
        private readonly CepService _cepService;

        public CepController(CepService cepService)
        {
            _cepService = cepService;
        }

        [HttpGet]
        [Route("/{cep}")]
        [Authorize]
        public async Task<IActionResult> GetCep([FromRoute] string cep)
        {
            try
            {
                var result = await _cepService.GetCep(new CepRecord { Cep = cep});
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }
    }
}
