using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZnamenitostiController : ControllerBase
    {
        private readonly IGenericRepository<Znamenitost> _znamenitostRepo;
        private readonly IGenericRepository<Veomaznamenito> _veomaznamenitoRepo;
        private readonly IGenericRepository<Nezaobilazno> _nezaobilaznoRepo;

        public ZnamenitostiController(IGenericRepository<Znamenitost> znamenitostRepo,
        IGenericRepository<Veomaznamenito> veomaznamenitoRepo, IGenericRepository<Nezaobilazno> nezaobilaznoRepo)
        {
            _nezaobilaznoRepo = nezaobilaznoRepo;
            _veomaznamenitoRepo = veomaznamenitoRepo;
            _znamenitostRepo = znamenitostRepo;

        }

        [HttpGet]
        public async Task<ActionResult<List<ZnamenitostiToReturnDto>>> GetZnamenitosti()
        {
            var spec = new veomaznameniteinezaobilazneSpecifications();

            var znamenitosti = await _znamenitostRepo.ListAsync(spec);
            
            return znamenitosti.Select(znamenitost => new ZnamenitostiToReturnDto {
                Id = znamenitost.Id,
               Naziv = znamenitost.Naziv,
               Koordinate = znamenitost.Koordinate,
               Opis = znamenitost.Opis,
               Veomaznamenito = znamenitost.Veomaznamenito.Naziv,
               Nezaobilazno = znamenitost.Nezaobilazno.Naziv 
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ZnamenitostiToReturnDto>> GetZnamenitost(int id)
        {
            var spec = new veomaznameniteinezaobilazneSpecifications(id);
           var znamenitost =  await _znamenitostRepo.GetEntityWithSpec(spec);
           return new ZnamenitostiToReturnDto
           {
               Id = znamenitost.Id,
               Naziv = znamenitost.Naziv,
               Koordinate = znamenitost.Koordinate,
               Opis = znamenitost.Opis,
               Veomaznamenito = znamenitost.Veomaznamenito.Naziv,
               Nezaobilazno = znamenitost.Nezaobilazno.Naziv 
           };
        }
        [HttpGet("veomaznamenite")]

        public async Task<ActionResult<IReadOnlyList<Veomaznamenito>>> GetVeomaznamenito()
        {
            return Ok(await _veomaznamenitoRepo.ListAllAsync());
        }
        [HttpGet("nezaobilazne")]

        public async Task<ActionResult<IReadOnlyList<Nezaobilazno>>> GetNezaobilazno()
        {
            return Ok(await _nezaobilaznoRepo.ListAllAsync());
        }

    }
}