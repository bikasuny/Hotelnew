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
        private readonly GenericRepository<room> _roomService;
        private readonly ILogger<RoomService> _logger;
        private readonly IMapper _mapper;




        public RoomService(GenericRepository<room> roomService, ILogger<RoomService> logger, IMapper mapper)
        {
            _roomService = roomService;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task AddRoom(RoomDto req)
        {
            _logger.LogInformation("Start logging data: {@room}", req);
            if (req == null) throw new ArgumentNullException("the request is null");
            var exists = _roomService.Predicate(i => i.Name == req.Name);

            if (exists) throw new AccessViolationException("Such room already exists");

            var mapped = _mapper.Map<room>(req);
            await _roomService.AddAsync(mapped);
            _logger.LogInformation("room insert complete successfully");
        }

        public async Task<List<RoomDto>> GetAllRooms()
        {
            _logger.LogInformation("Start logging all the rooms");
            var rooms = await _roomService.GetAllAsync();
            var mappedrooms = _mapper.Map<List<RoomDto>>(rooms);
            _logger.LogInformation("returned room {@data}", rooms);
            return mappedrooms;
        }

        public async Task<RoomDto> GetRoomByName(string name)
        {
            var roomByName = _roomService.Filter(i => i.Name == name).FirstOrDefault();
            var mapped = _mapper.Map<RoomDto>(roomByName);
            return mapped;
        }

        public async Task DeleteByName(string name)
        {
            var room = GetCityByName(name);
            if (room == null)
            {
                _logger.LogInformation("The city is null");
                throw new ArgumentNullException("The city is null");
            }
            await _roomService.RemoveByIdAsync(room.Id);
        }
    }
}
