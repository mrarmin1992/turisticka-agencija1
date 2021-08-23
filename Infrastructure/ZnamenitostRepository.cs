using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ZnamenitostRepository : IZnamenitostiRepository
    {
        private readonly StoreContext _context;
        public ZnamenitostRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Znamenitost>> GetZnamenitostAsync()
        {
            return await _context.Znamenitosti.ToListAsync();
        }

        public async Task<Znamenitost> GetZnamenitostByIdAsync(int id)
        {
            return await _context.Znamenitosti.FindAsync(id);
        }
    }
}