using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ZnamenitostiController : BaseApiController
    {
        private readonly IGenericRepository<Znamenitost> _znamenitostRepo;
        private readonly IGenericRepository<Veomaznamenito> _veomaznamenitoRepo;
        private readonly IGenericRepository<Nezaobilazno> _nezaobilaznoRepo;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoService _photoService;

        public ZnamenitostiController(IGenericRepository<Znamenitost> znamenitostRepo,
        IGenericRepository<Veomaznamenito> veomaznamenitoRepo, IGenericRepository<Nezaobilazno> nezaobilaznoRepo, IMapper mapper, IUnitOfWork unitOfWork, IPhotoService photoService)
        {
            _photoService = photoService;
            _unitOfWork = unitOfWork;

            _mapper = mapper;
            _nezaobilaznoRepo = nezaobilaznoRepo;
            _veomaznamenitoRepo = veomaznamenitoRepo;
            _znamenitostRepo = znamenitostRepo;

        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ZnamenitostiToReturnDto>>> GetZnamenitosti([FromQuery] ZnamenitostSpecParams znamenitostiparams)
        {
            var spec = new veomaznameniteinezaobilazneSpecifications(znamenitostiparams);
            var countSpec = new ZnamenitostiwithFiltersForCountSpecifications(znamenitostiparams);
            var totalItems = await _unitOfWork.Repository<Znamenitost>().CountAsync(countSpec);
            var znamenitosti = await _unitOfWork.Repository<Znamenitost>().ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Znamenitost>, IReadOnlyList<ZnamenitostiToReturnDto>>(znamenitosti);

            return Ok(new Pagination<ZnamenitostiToReturnDto>(znamenitostiparams.PageIndex, znamenitostiparams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ZnamenitostiToReturnDto>> GetZnamenitost(int id)
        {
            var spec = new veomaznameniteinezaobilazneSpecifications(id);
            var znamenitost = await _unitOfWork.Repository<Znamenitost>().GetEntityWithSpec(spec);

            if (znamenitost == null) return NotFound(new ApiResponse(404));
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

        [HttpPost]
 [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ZnamenitostiToReturnDto>> CreateZnamenitost(ZnamenitostToCreate znamenitostToCreate)
        {
            var znamenitost = _mapper.Map<ZnamenitostToCreate, Znamenitost>(znamenitostToCreate);

            _unitOfWork.Repository<Znamenitost>().Add(znamenitost);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem creating product"));

            return _mapper.Map<Znamenitost, ZnamenitostiToReturnDto>(znamenitost);
        }

        [HttpPut("{id}")]
     [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ZnamenitostiToReturnDto>> UpdateZnamenitost(int id, ZnamenitostiToReturnDto znamenitostToUpdate)
        {
            var znamenitost = await _unitOfWork.Repository<Znamenitost>().GetByIdAsync(id);

            _mapper.Map(znamenitostToUpdate, znamenitost);

            _unitOfWork.Repository<Znamenitost>().Update(znamenitost);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem updating product"));

            return _mapper.Map<Znamenitost, ZnamenitostiToReturnDto>(znamenitost);
        }
        [HttpDelete("{id}")]
     [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteZnamenitost(int id)
        {
            var znamenitost = await _unitOfWork.Repository<Znamenitost>().GetByIdAsync(id);
            foreach (var photo in znamenitost.Photos)
            {
                if (photo.Id > 18)
                {
                    _photoService.DeleteFromDisk(photo);
                }
            }

            _unitOfWork.Repository<Znamenitost>().Delete(znamenitost);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem deleting product"));

            return Ok();
        }

    }
}