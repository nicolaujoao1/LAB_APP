using LAB_APP.Application.DTOs;
using LAB_APP.Application.ExtensionDTOs;
using LAB_APP.Domain.Interfaces;

namespace LAB_APP.Application.Services
{
    public class ProvinciaService : IProvinciaService
    {
        private readonly IProvinciaRepository _repository;

        public ProvinciaService(IProvinciaRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddProvinceToCountryAsync(DadosPaisDTO dadosPais)
        {
            return await _repository.AddProvinceToCountryAsync(dadosPais.FromListDTOs());
        }

        public async Task<DadosPaisDTO> GetAllProvinceAsync()
        {
            var provincias = await _repository.GetAllProvinceAsync();

            return provincias.FromListDTOs();

        }

        public async Task<ProvinciaDTO> GetProvinceByCapitalNameAsync(string capital)
        {
            var provincia = await _repository.GetProvinceByCapitalNameAsync(capital);
            return provincia.FromDTO();
        }

        public async Task<ProvinciaDTO> GetProvinceByNameAsync(string name)
        {
            var provincia = await _repository.GetProvinceByNameAsync(name);
            return provincia.FromDTO();
        }
    }
}
