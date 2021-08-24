using System.Collections.Generic;
using System.Linq;
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

        public async Task<IReadOnlyList<Nezaobilazno>> GetNezaobilazneAsync()
        {
            return await _context.Nezaobilazne.ToListAsync();
        }

        public async Task<IReadOnlyList<Veomaznamenito>> GetVeomaznameniteAsync()
        {
            return await _context.Veomaznamenite.ToListAsync();
        }

        public async Task<IReadOnlyList<Znamenitost>> GetZnamenitostAsync()
        {
            return await _context.Znamenitosti
            .Include(p =>p.Nezaobilazno)
            .Include(p =>p.Veomaznamenito)
            .ToListAsync();
        }

        public async Task<Znamenitost> GetZnamenitostByIdAsync(int id)
        {
            return await _context.Znamenitosti
            .Include(p =>p.Nezaobilazno)
            .Include(p =>p.Veomaznamenito)
            .FirstOrDefaultAsync(p =>p.Id == id);
        }
    }
}