using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ZnamenitostiController : BaseApiController
    {
        private readonly IGenericRepository<Znamenitost> _znamenitostRepo;
        private readonly IGenericRepository<Veomaznamenito> _veomaznamenitoRepo;
        private readonly IGenericRepository<Nezaobilazno> _nezaobilaznoRepo;
        private readonly IMapper _mapper;

        public ZnamenitostiController(IGenericRepository<Znamenitost> znamenitostRepo,
        IGenericRepository<Veomaznamenito> veomaznamenitoRepo, IGenericRepository<Nezaobilazno> nezaobilaznoRepo, IMapper mapper)
        {
            _mapper = mapper;
            _nezaobilaznoRepo = nezaobilaznoRepo;
            _veomaznamenitoRepo = veomaznamenitoRepo;
            _znamenitostRepo = znamenitostRepo;

        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ZnamenitostiToReturnDto>>> GetZnamenitosti([FromQuery]ZnamenitostSpecParams znamenitostiparams)
        {
            var spec = new veomaznameniteinezaobilazneSpecifications(znamenitostiparams);
            var countSpec = new ZnamenitostiwithFiltersForCountSpecifications(znamenitostiparams);
            var totalItems = await _znamenitostRepo.CountAsync(countSpec);
            var znamenitosti = await _znamenitostRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Znamenitost>, IReadOnlyList<ZnamenitostiToReturnDto>>(znamenitosti);

            return Ok(new Pagination<ZnamenitostiToReturnDto>(znamenitostiparams.PageIndex, znamenitostiparams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ZnamenitostiToReturnDto>> GetZnamenitost(int id)
        {
            var spec = new veomaznameniteinezaobilazneSpecifications(id);
            var znamenitost = await _znamenitostRepo.GetEntityWithSpec(spec);

            if(znamenitost == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<Znamenitost, ZnamenitostiToReturnDto>(znamenitost);
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