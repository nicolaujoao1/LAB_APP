using LAB_APP.Data.Context;
using LAB_APP.Domain.Entities;
using LAB_APP.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_APP.Data.Repositories
{
    public class ProvinciaRepository : IProvinciaRepository
    {
        private readonly AppDbContext _context;
        public ProvinciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProvinceToCountryAsync(DadosPais dadosPais)
        {
            foreach (var provincia in dadosPais?.Angola?.Provincias?.ToList())
            {
                _context.Provincias.AddAsync(provincia);
                await _context.Commit();
            }

            return true;

        }

        public async Task<DadosPais> GetAllProvinceAsync()
        {
            var result = await _context.Provincias.ToListAsync();
            return new DadosPais
            {
                Angola = new Angola
                {
                    Provincias = result
                }
            };
        }

        public async Task<Provincia> GetProvinceByCapitalNameAsync(string capital)
        {
            var provincia = await _context.Provincias.FirstOrDefaultAsync(c => c.Capital.Equals(capital));
            return provincia;
        }

        public async Task<Provincia> GetProvinceByNameAsync(string name)
        {
            var provincia = await _context.Provincias.FirstOrDefaultAsync(c => c.Nome.Equals(name));
            return provincia;
        }
    }
}
