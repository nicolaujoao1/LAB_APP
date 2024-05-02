using LAB_APP.Application.DTOs;

namespace LAB_APP.Application.Services
{
    public interface IProvinciaService
    {
        Task<DadosPaisDTO> GetAllProvinceAsync();
        Task<bool> AddProvinceToCountryAsync(DadosPaisDTO dadosPais);
        Task<ProvinciaDTO> GetProvinceByNameAsync(string name);
        Task<ProvinciaDTO> GetProvinceByCapitalNameAsync(string capital);
    }
}
