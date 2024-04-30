using LAB_APP.Data.Context;
using LAB_APP.Domain.Entities;
using LAB_APP.Domain.Interfaces;

namespace LAB_APP.Data.Repositories
{
    public class EscolaRepository : Repository<Escola>, IEscolaRepository
    {
        public EscolaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
