using LAB_APP.Application.DTOs;
using LAB_APP.Domain.Entities;

namespace LAB_APP.Application.ExtensionDTOs
{
    public static class EscolaExtension
    {
        public static EscolaDTO FromModel(this Escola escola) => new EscolaDTO
        {
            Id = escola.Id,
            Nome = escola.Nome,
            Email = escola.Email,
            NumeroDeSalas = escola.NumeroDeSalas,
            Provincia = escola.Provincia
        };

        public static Escola FromDTO(this EscolaDTO escolaDTO) => new Escola
        {
            Id = escolaDTO.Id,
            Nome = escolaDTO.Nome,
            Email = escolaDTO.Email,
            NumeroDeSalas = escolaDTO.NumeroDeSalas,
            Provincia = escolaDTO.Provincia
        };
    }
}
