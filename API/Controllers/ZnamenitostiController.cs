using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZnamenitostiController : ControllerBase
    {
        private readonly IZnamenitostiRepository _repo;

        public ZnamenitostiController(IZnamenitostiRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Znamenitost>>> GetZnamenitosti()
        {
            var znamenitosti = await _repo.GetZnamenitostAsync();
            return Ok(znamenitosti);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Znamenitost>> GetZnamenitost(int id)
        {
            return await _repo.GetZnamenitostByIdAsync(id);
        }
        [HttpGet("veomaznamenite")]

        public async Task<ActionResult<IReadOnlyList<Veomaznamenito>>> GetVeomaznamenito()
        {
            return Ok(await _repo.GetVeomaznameniteAsync());
        }
         [HttpGet("nezaobilazne")]

        public async Task<ActionResult<IReadOnlyList<Nezaobilazno>>> GetNezaobilazno()
        {
            return Ok(await _repo.GetNezaobilazneAsync());
        }

    }
}