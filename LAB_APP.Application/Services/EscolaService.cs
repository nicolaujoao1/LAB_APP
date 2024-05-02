using LAB_APP.Application.DTOs;
using LAB_APP.Application.ExtensionDTOs;
using LAB_APP.Domain.Interfaces;

namespace LAB_APP.Application.Services
{
    public class EscolaService : IEscolaService
    {
        private readonly IEscolaRepository _repository;

        public EscolaService(IEscolaRepository repository)
        {
            _repository = repository;
        }

        public async Task<EscolaDTO> CreateAsync(EscolaDTO escolaDTO)
        {

            var escola = await _repository.CreateAsync(escolaDTO.FromDTO());

            return escola.FromModel();

        }

        public async Task<EscolaDTO> DeleteAsync(EscolaDTO escolaDTO)
        {
            var escola = await _repository.DeleteAsync(escolaDTO.FromDTO());

            return escola.FromModel();
        }

        public IEnumerable<EscolaDTO> GetAll()
        {
            var escolas = _repository.GetAll();

            return escolas.Select(e => e.FromModel());
        }

        public async Task<EscolaDTO> GetById(int id)
        {
            var escola = await _repository.GetById(id);

            return escola is null ? new EscolaDTO() : escola.FromModel();
        }

        public async Task<EscolaDTO> UpdateAsync(EscolaDTO escolaDTO)
        {
            var escola = await _repository.UpdateAsync(escolaDTO.FromDTO());

            return escola.FromModel();
        }
    }
}
