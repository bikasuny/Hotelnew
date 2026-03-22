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
    public class RoomService
    {
        private readonly GenericRepository<Rooms> _roomsService;
        private readonly ILogger<RoomService> _logger;
        private readonly IMapper _mapper;


        public RoomService(GenericRepository<Rooms> RoomService, ILogger<RoomService> logger, IMapper mapper)
        {

            _roomsService = RoomService;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task AddRoom(RoomDto req)
        {
            _logger.LogInformation("Start logging data: {@Rooms}", req);
            if (req == null) throw new ArgumentNullException("the request is null");
            var exists = _roomsService.Predicate(i => i.Name == req.Name);

            if (exists) throw new AccessViolationException("Such Room already exists");

            var mapped = _mapper.Map<Rooms>(req);
            await _roomsService.AddAsync(mapped);
            _logger.LogInformation("Room insert complete successfully");
        }

        public async Task<List<RoomDto>> GetAllRooms()
        {
            _logger.LogInformation("Start logging all the cities");
            var rooms = await _roomsService.GetAllAsync();
            var mappedrooms = _mapper.Map<List<RoomDto>>(rooms);
            _logger.LogInformation("returned Rooms {@data}", rooms);
            return mappedrooms;
        }

        public async Task<RoomDto> GetHotelByName(string name)
        {
            var cityByName = _roomsService.Filter(i => i.Name == name).FirstOrDefault();
            var mapped = _mapper.Map<RoomDto>(cityByName);
            return mapped;
        }

        public async Task DeleteByName(string name)
        {
            var room = GetHotelByName(name);
            if (room == null)
            {
                _logger.LogInformation("The  is null");
                throw new ArgumentNullException("The  is null");
            }
            await _roomsService.RemoveByIdAsync(room.Id);
        }
    }
}
