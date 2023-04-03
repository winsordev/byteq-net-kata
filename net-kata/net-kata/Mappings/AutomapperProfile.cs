using AutoMapper;
using net_kata.Dtos;
using net_kata.Models;

namespace net_kata.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Habitacion, HabitacionDto>().ReverseMap();
            CreateMap<Huesped, HuespedDto>().ReverseMap();
            CreateMap<HuespedHabitacion, HuespedHabitacionDto>().ReverseMap();
        }
    }
}
