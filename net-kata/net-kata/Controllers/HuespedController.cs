using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using net_kata.Dtos;
using net_kata.Interface;
using net_kata.Models;

namespace net_kata.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HuespedController : ControllerBase
    {
        private readonly IRepository<Huesped> _HuespedRepository;
        private readonly IMapper _mapper;

        public HuespedController(
            IRepository<Huesped> HuespedRepository,
            IMapper mapper)
        {
            _HuespedRepository = HuespedRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var huesped = _HuespedRepository.GetAll().AsQueryable();
            return Ok(huesped);
        }

        [HttpGet("{id}")]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var huesped = await _HuespedRepository.GetById(id);
            return Ok(huesped);
        }

        [HttpPut("action")]
        [Route("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Add(HuespedDto item)
        {
            try
            {
                var huesped = _mapper.Map<Huesped>(item);
                await _HuespedRepository.Add(huesped);
                return Ok(new { Save = true });
            }
            catch (SqlException sqlError)
            {
                return NotFound(sqlError.Message);
            }
        }

        [HttpPost("action")]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(HuespedDto item)
        {
            try
            {
                var huesped = _mapper.Map<Huesped>(item);
                await _HuespedRepository.Update(huesped);
                return Ok(true);
            }
            catch (SqlException sqlError)
            {
                return NotFound(sqlError.Message);
            }
        }
    }
}
