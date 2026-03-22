using Hotel.Application.Dto;
using Hotel.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelService _hotelService;
        public HotelController(HotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost("AddCity")]
        public async Task<IActionResult> AddHotel(HotelDto req)
        {
            await _hotelService.AddHotel(req);
            return Ok("Added Hotel successfully");
        }

        [HttpGet("GetAllHotels")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _hotelService.GetAllHotels());
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var hotel = await _hotelService.GetHotelByName(name);
            if (hotel == null) return NotFound("hotel not found with the provided name");
            return Ok(hotel);
        }

        [HttpDelete("Hotel/{name}")]
        public async Task<IActionResult> DeleteHotel(string name)
        {
            await _hotelService.DeleteByName(name);
            return Ok();
        }
    }
}
