using Hotel.Application.Dto;
using Hotel.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly RoomService _roomService;
        public RoomController(RoomService roomService)
        {
            _roomService = roomService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            return Ok(await _roomService.GetRoomById(id));
        }

        [HttpPost("AddRoom")]
        public async Task<IActionResult> AddRoom(RoomDto req)
        {
            await _roomService.AddRoom(req);
            return Ok("Added Room successfully");
        }

        [HttpDelete("DeleteRoomById")]

        public async Task<IActionResult> RemoveRoom(int Id)
        {
            await _roomService.DeleteById(Id);
            return Ok();
        }

        [HttpGet("GetAllRooms")]

        public async Task<IActionResult> GetAllRooms()
        {
            await _roomService.GetAllRooms();
            return Ok();
        }
    }
}
