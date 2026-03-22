using AutoMapper;
using Hotel.Application.Dto;
using Hotel.Core.Entities;
using Hotel.Core.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
    public class HotelService
    {
        private readonly GenericRepository<Hotel.Core.Entities.Hotel> _hotelService;
        private readonly ILogger<HotelService> _logger;
        private readonly IMapper _mapper;

        public HotelService(GenericRepository<Hotel.Core.Entities.Hotel> hotelService, ILogger<HotelService> logger, IMapper mapper)
        {
            _hotelService = hotelService;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task AddHotel(HotelDto req)
        {
            _logger.LogInformation("Start logging data: {@hotel}", req);
            if (req == null) throw new ArgumentNullException("the request is null");
            var exists = _hotelService.Predicate(i => i.Name == req.Name);

            if (exists) throw new AccessViolationException("Such hotel already exists");

            var mapped = _mapper.Map<Hotel.Core.Entities.Hotel>(req);
            await _hotelService.AddAsync(mapped);
            _logger.LogInformation("hotel insert complete successfully");
        }

        public async Task<List<HotelDto>> GetAllHotels()
        {
            _logger.LogInformation("Start logging all the rooms");
            var hotels = await _hotelService.GetAllAsync();
            var mappedhotels = _mapper.Map<List<HotelDto>>(hotels);
            _logger.LogInformation("returned room {@data}", hotels);
            return mappedhotels;
        }

        public async Task<HotelDto> GetHotelByName(string name)
        {
            var HotelByName = _hotelService.Filter(i => i.Name == name).FirstOrDefault();
            var mapped = _mapper.Map<HotelDto>(HotelByName);
            return mapped;
        }

        public async Task DeleteByName(string name)
        {
            var hotel = GetHotelByName(name);
            if (hotel == null)
            {
                _logger.LogInformation("The hotel is null");
                throw new ArgumentNullException("The hotel is null");
            }
            await _hotelService.RemoveByIdAsync(hotel.Id);
        }

    }
}