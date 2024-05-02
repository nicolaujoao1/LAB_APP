using LAB_APP.Domain.Entities;

namespace LAB_APP.Domain.Interfaces
{
    public interface IProvinciaRepository 
    {
        Task<DadosPais> GetAllProvinceAsync();
        Task<bool> AddProvinceToCountryAsync(DadosPais dadosPais);
        Task<Provincia> GetProvinceByNameAsync(string name);
        Task<Provincia> GetProvinceByCapitalNameAsync(string capital);


    }
}
