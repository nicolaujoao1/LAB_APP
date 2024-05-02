using LAB_APP.Application.DTOs;
using LAB_APP.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LAB_APP.API.Controllers
{
    /// <summary>
    /// Controller responsável pelas operações relacionadas às Províncias.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private readonly IProvinciaService _provinciaService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="provinciaService"></param>
        public ProvinciaController(IProvinciaService provinciaService)
        {
            _provinciaService = provinciaService;
        }

        /// <summary>
        /// Obtém todas as províncias disponíveis.
        /// </summary>
        /// <returns>Lista de províncias</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAll()
        {
            var provincia = await _provinciaService.GetAllProvinceAsync();
            return Ok(provincia);
        }


        /// <summary>
        /// Obtém uma província pelo nome.
        /// </summary>
        /// <param name="nome">Nome da província</param>
        /// <returns>Informações da província</returns>
        [HttpGet("provincia-por-nome")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetByName(string nome)
        {
            var provincia = await _provinciaService.GetProvinceByNameAsync(nome);

            return string.IsNullOrEmpty(provincia.Capital)
                ? NotFound($"Provincia com nome {nome} inexistente em Angola!")
                : Ok(provincia);
        }

        /// <summary>
        /// Obtém uma província pelo nome da capital.
        /// </summary>
        /// <param name="capital">Nome da capital</param>
        /// <returns>Informações da província</returns>
        [HttpGet("provincia-por-capital")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetByCapitalName(string capital)
        {
            var provincia = await _provinciaService.GetProvinceByCapitalNameAsync(capital);

            return string.IsNullOrEmpty(provincia.Capital)
                ? NotFound($"Capital com nome {capital} inexistente em Angola!")
                : Ok(provincia);
        }

        /// <summary>
        /// Adiciona uma nova província ao país.
        /// </summary>
        /// <param name="dadosPaisDTO">Dados da província a ser adicionada</param>
        /// <returns>Informações da província adicionada</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Post(DadosPaisDTO dadosPaisDTO)
        {
            var provincia = await _provinciaService.AddProvinceToCountryAsync(dadosPaisDTO);

            return Ok(provincia);
        }

    }
}
