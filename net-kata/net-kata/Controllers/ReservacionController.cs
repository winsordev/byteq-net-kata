using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using net_kata.Dtos;
using net_kata.Interface;
using net_kata.Models;
using Newtonsoft.Json;

namespace net_kata.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservacionController : ControllerBase
    {
        private readonly IRepository<HuespedHabitacion> _ReservacionRepository;
        private readonly IMapper _mapper;
        public ReservacionController(
            IRepository<HuespedHabitacion> ReservacionRepository,
            IMapper mapper)
        {
            _ReservacionRepository = ReservacionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var reservaciones = _ReservacionRepository.GetAll().AsQueryable()
                .Include(x=> x.Habitaciones)
                .Include(x => x.Huesped)
                .Select(x=> new {
                    x.HabitacionId,
                    x.HuespedId,
                    x.FechaEntrada,
                    x.FechaSalida,
                    Huesped = $"{x.Huesped.Identificacion} - {x.Huesped.Nombre} {x.Huesped.Apellido}",
                    Telefono = $"{x.Huesped.Telefono}"
                }).ToList();

            return Ok(reservaciones);
        }

        [HttpGet("{id}")]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var reservacion = await _ReservacionRepository.GetById(id);
            return Ok(reservacion);
        }

        [HttpPut("action")]
        [Route("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Add(HuespedHabitacionDto item)
        {
            try
            {
                string message = String.Empty;
                // Validar si el Huesped ya tiene una reservacion
                var reservaciones = _ReservacionRepository.GetAll().AsQueryable().Include(x => x.Habitaciones)
                .Include(x => x.Huesped);
                var existeReservacionHuesped = reservaciones.Where(x => x.HuespedId == item.HuespedId).FirstOrDefault();
                var estaDisponibleHabitacion = reservaciones.Where(x => x.HabitacionId == item.HabitacionId).FirstOrDefault();

                var currentDate = DateTime.Now;

                if (item.FechaSalida > currentDate)
                {
                    if (existeReservacionHuesped == null && estaDisponibleHabitacion == null)
                    {
                        var reservacion = _mapper.Map<HuespedHabitacion>(item);
                        await _ReservacionRepository.Add(reservacion);
                        return Ok(new { Save = true });
                    }
                    else
                    {
                        // Mensaje si Huesped tiene reservacion
                        if (existeReservacionHuesped != null)
                        {
                            message = $"Estimado Huesped: {existeReservacionHuesped?.Huesped.Nombre} {existeReservacionHuesped?.Huesped.Apellido}" +
                                $" ya cuenta con una reservacion \n";
                        }

                        if (estaDisponibleHabitacion != null)
                        {
                            message += $"La habitación: {estaDisponibleHabitacion?.Habitaciones.Descripcion} ya se encuentra reservada";
                        }

                        return Ok(new { Error = message });
                    }
                }
                else {
                    // Mensaje si Fecha Salida no es mayor que fecha actual
                    message = $"La Fecha de salida debe ser mayor que la actual";
                    return Ok(new { Error = message });
                }
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
        public async Task<IActionResult> Update(HuespedHabitacionDto item)
        {
            try
            {
                var reservacion = _mapper.Map<HuespedHabitacion>(item);
                await _ReservacionRepository.Update(reservacion);
                return Ok(true);
            }
            catch (SqlException sqlError)
            {
                return NotFound(sqlError.Message);
            }
        }
    }
}
