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
    internal class BookedRoomService
    {
        private readonly GenericRepository<BookedRoom> _bookedroomService;
        private readonly ILogger<BookedRoomService> _logger;
        private readonly IMapper _mapper;

        public BookedRoomService(GenericRepository<BookedRoom> bookedroomservice, ILogger<BookedRoomService> logger, IMapper mapper)
        {
            _bookedroomService = bookedroomservice;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task AddBookedRoom(BookedRoomDto req)
        {
            _logger.LogInformation("Start logging data: {@bookedroom}", req);
            if (req == null) throw new ArgumentNullException("the request is null");
            var exists = _bookedroomService.Predicate(i => i.Name == req.Name);

            if (exists) throw new AccessViolationException("Such booked room already exists");

            var mapped = _mapper.Map<BookedRoom>(req);
            await _bookedroomService.AddAsync(mapped);
            _logger.LogInformation("booked room insert complete successfully");
        }

        public async Task<List<BookedRoomDto>> GetAllBookedRooms()
        {
            _logger.LogInformation("Start logging all the cities");
            var bookedRooms = await _bookedroomService.GetAllAsync();
            var mappedbookedrooms = _mapper.Map<List<BookedRoomDto>>(bookedRooms);
            _logger.LogInformation("returned hotels {@data}", bookedRooms);
            return mappedbookedrooms;
        }

        public async Task<BookedRoomDto> GetBookedRoomByName(string name)
        {
            var cityByName = _bookedroomService.Filter(i => i.Name == name).FirstOrDefault();
            var mapped = _mapper.Map<BookedRoomDto>(cityByName);
            return mapped;
        }

        public async Task DeleteByName(string name)
        {
            var booked = GetBookedRoomByName(name);
            if (booked == null)
            {
                _logger.LogInformation("The booked room is null");
                throw new ArgumentNullException("The booked room is null");
            }
            await _bookedroomService.RemoveByIdAsync(booked.Id);
        }
    }
}
