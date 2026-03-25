using AutoMapper;
using Hotel.Application.Dto;
using Hotel.Core.Entities;
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
            CreateMap<CityHotel, HotelDto>().ReverseMap();
        }
    }
}
