using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IZnamenitostiRepository
    {
        Task<Znamenitost> GetZnamenitostByIdAsync(int id);
        Task<IReadOnlyList<Znamenitost>> GetZnamenitostAsync();
        Task<IReadOnlyList<Veomaznamenito>> GetVeomaznameniteAsync();
        Task<IReadOnlyList<Nezaobilazno>> GetNezaobilazneAsync();
    }
}