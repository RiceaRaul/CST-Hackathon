using Asp_NET_Core_6_Template.Attributes;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Rooms;

namespace Asp_NET_Core_6_Template.Controllers
{
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        [Authorize]
        [Route("/room/createroom")]
        public async Task<ActionResult<Room>> CreateRoom()
        {
            var result = await _roomService.GenerateRoom();

            return Ok(result);
        }
    }
}
