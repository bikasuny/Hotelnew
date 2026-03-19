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
    public class CityService
    {
        private readonly GenericRepository<City> _cityService;
        private readonly ILogger<CityService> _logger;
        private readonly IMapper _mapper;




        public CityService(GenericRepository<City> cityService, ILogger<CityService> logger, IMapper mapper)
        {
            _cityService = cityService;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task AddCity(CityDto req)
        {
            _logger.LogInformation("Start logging data: {@city}", req);
            if (req == null) throw new ArgumentNullException("the request is null");
            var exists = _cityService.Predicate(i => i.Name == req.Name);

            if (exists) throw new AccessViolationException("Such city already exists");

            var mapped = _mapper.Map<City>(req);
            await _cityService.AddAsync(mapped);
            _logger.LogInformation("City insert complete successfully");
        }

        public async Task<List<CityDto>> GetAllCities()
        {
            _logger.LogInformation("Start logging all the cities");
            var cities = await _cityService.GetAllAsync();
            var mappedCities = _mapper.Map<List<CityDto>>(cities);
            _logger.LogInformation("returned cities {@data}", cities);
            return mappedCities;
        }

        public async Task<CityDto> GetCityByName(string name)
        {
            var cityByName = _cityService.Filter(i => i.Name == name).FirstOrDefault();
            var mapped = _mapper.Map<CityDto>(cityByName);
            return mapped;
        }

        public async Task DeleteByName(string name)
        {
            var city = GetCityByName(name);
            if (city == null)
            {
                _logger.LogInformation("The city is null");
                throw new ArgumentNullException("The city is null");
            }
            await _cityService.RemoveByIdAsync(city.Id);
        }
    }
}