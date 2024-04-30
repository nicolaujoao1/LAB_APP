using LAB_APP.Application.DTOs;

namespace LAB_APP.Application.Services
{
    public interface IEscolaService
    {
        IEnumerable<EscolaDTO> GetAll();
        Task<EscolaDTO> GetById(int id);
        Task<EscolaDTO> CreateAsync(EscolaDTO escolaDTO);
        Task<EscolaDTO> UpdateAsync(EscolaDTO escolaDTO);
        Task<EscolaDTO> DeleteAsync(EscolaDTO escolaDTO);
    }

}
