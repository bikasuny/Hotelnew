using Hotel.Application.Dto;
using Hotel.Application.Services;
using Hotel.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost("AddCity")]
        public async Task<IActionResult> AddCity(CityDto req)
        {
            await _cityService.AddCity(req);
            return Ok("Added city successfully");
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _cityService.GetAllCities());
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var city = await _cityService.GetCityByName(name);
            if (city == null) return NotFound("City not found with the provided name");
            return Ok(city);
        }

        [HttpDelete("City/{name}")]
        public async Task<IActionResult> DeleteCity(string name)
        {
            await _cityService.DeleteByName(name);
            return Ok();
        }
    }
}
