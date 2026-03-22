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
    public class BookedRoomService
    {
        private readonly GenericRepository<BookedRoom> _bookedroomService;
        private readonly ILogger<BookedRoomService> _logger;
        private readonly IMapper _mapper;




        public BookedRoomService(GenericRepository<BookedRoom> bookedroomService, ILogger<BookedRoomService> logger, IMapper mapper)
        {
            _bookedroomService = bookedroomService;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task AddRoom(BookedRoomDto req)
        {
            _logger.LogInformation("Start logging data: {@bookedroom}", req);
            if (req == null) throw new ArgumentNullException("the request is null");
            var exists = _bookedroomService.Predicate(i => i.Name == req.Name);

            if (exists) throw new AccessViolationException("Such room already exists");

            var mapped = _mapper.Map<BookedRoom>(req);
            await _bookedroomService.AddAsync(mapped);
            _logger.LogInformation("room insert complete successfully");
        }

        public async Task<List<BookedRoomDto>> GetAllRooms()
        {
            _logger.LogInformation("Start logging all the rooms");
            var rooms = await _bookedroomService.GetAllAsync();
            var mappedrooms = _mapper.Map<List<BookedRoomDto>>(rooms);
            _logger.LogInformation("returned room {@data}", rooms);
            return mappedrooms;
        }

        public async Task<BookedRoomDto> GetRoomByName(string name)
        {
            var roomByName = _bookedroomService.Filter(i => i.Name == name).FirstOrDefault();
            var mapped = _mapper.Map<BookedRoomDto>(roomByName);
            return mapped;
        }

        public async Task DeleteByName(string name)
        {
            var broom = GetRoomByName(name);
            if (broom == null)
            {
                _logger.LogInformation("The room is null");
                throw new ArgumentNullException("The room is null");
            }
            await _bookedroomService.RemoveByIdAsync(broom.Id);
        }
    }
}
