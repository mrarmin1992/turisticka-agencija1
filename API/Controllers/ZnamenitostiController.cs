using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZnamenitostiController : ControllerBase
    {
        private readonly StoreContext _context;
        public ZnamenitostiController(StoreContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<Znamenitost>>> GetZnamenitosti()
        {
            var znamenitosti = await _context.Znamenitosti.ToListAsync();
            return Ok(znamenitosti);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Znamenitost>> GetZnamenitost(int id)
        {
            return await _context.Znamenitosti.FindAsync(id);
        }

    }
}