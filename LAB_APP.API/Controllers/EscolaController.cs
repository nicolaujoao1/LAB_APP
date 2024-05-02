using LAB_APP.API.Extensions;
using LAB_APP.API.Models;
using LAB_APP.Application.DTOs;
using LAB_APP.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LAB_APP.API.Controllers
{
    /// <summary>
    /// Controller responsável pelas operações relacionadas a Escolas.
    /// </summary>
    [Route("api/escola")]
    [ApiController]
    public class EscolaController : ControllerBase
    {
        private readonly IEscolaService _escolaService;
        private readonly IExcelService _excelService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="escolaService"></param>
        /// <param name="excelService"></param>
        public EscolaController(IEscolaService escolaService, IExcelService excelService)
        {
            _escolaService = escolaService;
            _excelService = excelService;
        }

        /// <summary>
        /// Retorna uma lista paginada de escolas.
        /// </summary>
        /// <param name="pageNumber">O número da página.</param>
        /// <param name="pageSize">O tamanho da página.</param>
        /// <returns>Uma lista de escolas paginada.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EscolaDTO>), 200)]
        public IActionResult GetAll(int pageNumber, int pageSize)
        {
            var escolas = _escolaService.GetAll(pageNumber, pageSize);
            return Ok(escolas);
        }

        /// <summary>
        /// Buscar escola por Id
        /// </summary>
        /// <param name="id">código da escola</param>
        /// <returns>Escola</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var escola = await _escolaService.GetById(id);
            return string.IsNullOrEmpty(escola.Nome) ? NotFound($"Escola com Id={id} inexistente!") : Ok(escola);
        }


        /// <summary>
        /// Incluir uma escola.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     POST api/escola
        ///     {
        ///         "nome": "escola II",
        ///         "email": "escolaii@gmail.com",
        ///         "numeroDeSalas": 12,
        ///         "provincia": "Luanda"
        ///     }
        /// </remarks>
        /// <param name="escolaViewModel">Escola</param>
        /// <returns>O objeto escola que foi cadastrado</returns>
        [HttpPost]
        [ProducesResponseType(typeof(EscolaDTO), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post(EscolaViewModel escolaViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var escola = await _escolaService.CreateAsync(escolaViewModel.ToDTO());

            return Ok(escola);
        }


        /// <summary>
        /// Fazer upload de um arquivo Excel contendo dados das escolas e os insere no banco de dados.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     POST api/escola/upload-excel?filePath=caminho/do/arquivo
        ///     
        /// O parâmetro 'filePath' deve ser o caminho do arquivo Excel a ser carregado, sem a extensão '.xlsx'.
        /// </remarks>
        /// <param name="filePath">Caminho do arquivo Excel (sem extensão)</param>
        /// <returns>Mensagem de sucesso</returns>
        [HttpPost("upload-excel")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UploadExcel(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return BadRequest("Caminho do arquivo Excel não especificado.");
            }

            var escolas = _excelService.ReadDataFromExcel($"{filePath}.xlsx");

            foreach (var escola in escolas)
            {
                await _escolaService.CreateAsync(escola);
            }

            return Ok("Informações extraídas e inseridas com sucesso.");
        }



        /// <summary>
        /// Excluir uma escola pelo seu ID.
        /// </summary>
        /// <param name="id">ID da escola a ser excluída</param>
        /// <returns>O objeto escola que foi excluído</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(EscolaDTO), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var escola = await _escolaService.GetById(id);

            if (!string.IsNullOrEmpty(escola.Nome))
            {
                escola = await _escolaService.DeleteAsync(escola);

                return Ok(escola);
            }
            else
            {
                return NotFound($"Escola com Id={id} inexistente, não é possivel deletar!");
            }
        }


        /// <summary>
        /// Atualizar uma escola pelo seu ID.
        /// </summary>
        /// <param name="id">ID da escola a ser atualizada</param>
        /// <param name="escolaViewModel">Dados da escola a serem atualizados</param>
        /// <returns>O objeto escola que foi atualizado</returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(EscolaDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, EscolaViewModel escolaViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var escola = await _escolaService.GetById(id);

            if (escola is null) return NotFound($"Escola com ID {id} não encontrada.");

            escola.Nome = escolaViewModel.Nome;
            escola.Email = escolaViewModel.Email;
            escola.NumeroDeSalas = escolaViewModel.NumeroDeSalas;
            escola.Provincia = escolaViewModel.Provincia;

            escola = await _escolaService.UpdateAsync(escola);

            return Ok(escola);
        }

    }
}
