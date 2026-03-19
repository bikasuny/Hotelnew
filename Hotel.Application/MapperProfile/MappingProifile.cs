using AutoMapper;
using Hotel.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.MapperProfile
{
    public class MappingProifile: Profile
    {

        public MappingProifile() {

            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Hotel, HotelDto>.ReverseMap();
        }
    }
}
