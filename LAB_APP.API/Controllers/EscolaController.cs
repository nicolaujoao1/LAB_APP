using LAB_APP.API.Extensions;
using LAB_APP.API.Models;
using LAB_APP.Application.DTOs;
using LAB_APP.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LAB_APP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaController : ControllerBase
    {
        private readonly IEscolaService _escolaService;
        private readonly IExcelService _excelService;

        public EscolaController(IEscolaService escolaService, IExcelService excelService)
        {
            _escolaService = escolaService;
            _excelService = excelService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var escolas = _escolaService.GetAll();
            return Ok(escolas);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var escola = await _escolaService.GetById(id);
            return escola is null ? NotFound() : Ok(escola);
        }
        [HttpPost]
        public async Task<IActionResult> Post(EscolaViewModel escolaViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var escola = await _escolaService.CreateAsync(escolaViewModel.ToDTO());

            return Ok(escola);
        }
        [HttpPost("upload-excel")]
        public async Task<IActionResult> UploadExcel(string filePath)
        {
            var escolas = _excelService.ReadDataFromExcel($"{filePath}.xlsx");

            foreach (var escola in escolas)
            {
                await _escolaService.CreateAsync(escola);
            }

            return Ok("Informações extraidas"); 
        }



        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var escola = await _escolaService.GetById(id);
            escola = await _escolaService.DeleteAsync(escola);
            return Ok(escola);
        }
        [HttpPut]
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
