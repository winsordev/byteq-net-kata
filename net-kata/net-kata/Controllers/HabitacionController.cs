using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using net_kata.Dtos;
using net_kata.Interface;
using net_kata.Models;
using net_kata.Repositories;

namespace net_kata.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private readonly IRepository<Habitacion> _HabitacionRepository;
        private readonly IMapper _mapper;

        public HabitacionController(
            IRepository<Habitacion> HabitacionRepository,
            IMapper mapper)
        {
            _HabitacionRepository = HabitacionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var huesped = _HabitacionRepository.GetAll().AsQueryable();
            return Ok(huesped);
        }

        [HttpGet("{id}")]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var huesped = await _HabitacionRepository.GetById(id);
            return Ok(huesped);
        }

        [HttpPut("action")]
        [Route("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Add(HabitacionDto item)
        {
            try
            {
                var habitacion = _mapper.Map<Habitacion>(item);
                await _HabitacionRepository.Add(habitacion);
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
        public async Task<IActionResult> Update(HabitacionDto item)
        {
            try
            {
                var habitacion = _mapper.Map<Habitacion>(item);
                await _HabitacionRepository.Update(habitacion);
                return Ok(true);
            }
            catch (SqlException sqlError)
            {
                return NotFound(sqlError.Message);
            }
        }
    }
}
