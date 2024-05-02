using LAB_APP.Application.DTOs;
using LAB_APP.Application.Services;
using LAB_APP.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LAB_APP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private readonly IProvinciaService _provinciaService;

        public ProvinciaController(IProvinciaService provinciaService)
        {
            _provinciaService = provinciaService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var provincia = await _provinciaService.GetAllProvinceAsync();
            return Ok(provincia);
        }
        [HttpGet("provincia-por-nome")]
        public async Task<IActionResult> GetByName(string nome)
        {
            var provincia = await _provinciaService.GetProvinceByNameAsync(nome);

            return string.IsNullOrEmpty(provincia.Capital)
             ? NotFound($"Provincia com nome {nome} inexistente em Angola!") : Ok(provincia);

        }
        [HttpGet("provincia-por-capital")]
        public async Task<IActionResult> GetByCapitalName(string capital)
        {
            var provincia = await _provinciaService.GetProvinceByCapitalNameAsync(capital);

            return string.IsNullOrEmpty(provincia.Capital) 
                ? NotFound($"Capital com nome {capital} inexistente em Angola!") : Ok(provincia);

        }
        [HttpPost]
        public async Task<IActionResult> Post(DadosPaisDTO dadosPaisDTO)
        {
            var provincia= await _provinciaService.AddProvinceToCountryAsync(dadosPaisDTO); 

            return Ok(provincia);
        }

    }
}
