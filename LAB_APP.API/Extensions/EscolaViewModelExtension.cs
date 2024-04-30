using LAB_APP.API.Models;
using LAB_APP.Application.DTOs;

namespace LAB_APP.API.Extensions
{
    public static class EscolaViewModelExtension
    {
        public static EscolaDTO ToDTO(this EscolaViewModel escolaViewModel) => new EscolaDTO 
        { 
            Nome = escolaViewModel.Nome,
            Email = escolaViewModel.Email,  
            NumeroDeSalas=escolaViewModel.NumeroDeSalas,
            Provincia=escolaViewModel.Provincia
        };

    }
}
