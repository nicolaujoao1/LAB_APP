using LAB_APP.Application.DTOs;
using LAB_APP.Domain.Entities;
using System.Linq;

namespace LAB_APP.Application.ExtensionDTOs
{
    public static class ProvinceExtension
    {
        public static Provincia FromModel(this ProvinciaDTO provincia)
        {
            return provincia is null? new Provincia(): new Provincia
            {
                Nome = provincia.Nome,
                Capital = provincia.Capital
            };
        }
      
        public static ProvinciaDTO FromDTO(this Provincia provincia)
        {
            return provincia is null?new ProvinciaDTO(): new ProvinciaDTO
            {
                Nome = provincia.Nome,
                Capital = provincia.Capital
            };
        }
        
        public static DadosPais FromListDTOs(this DadosPaisDTO dadosPaisDTO)
        {
            List<Provincia> provincias = Enumerable.Empty<Provincia>().ToList();
            foreach (var provincia in dadosPaisDTO.Angola.Provincias)
            {
                provincias.Add(provincia.FromModel());
            }
            return new DadosPais
            {
                Angola = new Angola
                {
                    Provincias = provincias
                }
            };

        }

        public static DadosPaisDTO FromListDTOs(this DadosPais dadosPais)
        {
            List<ProvinciaDTO> provinciasDTO = Enumerable.Empty<ProvinciaDTO>().ToList();
            foreach (var provincia in dadosPais.Angola.Provincias)
            {
                provinciasDTO.Add(provincia.FromDTO());
            }
            return new DadosPaisDTO
            {
                Angola = new AngolaDTO
                {
                    Provincias = provinciasDTO
                }
            };

        }
    }
}
