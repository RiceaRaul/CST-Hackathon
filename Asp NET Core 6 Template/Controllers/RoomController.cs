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
        [Route("/Room/createroom")]
        public async Task<ActionResult<Room>> CreateRoom()
        {
            var result = await _roomService.GenerateRoom();

            return Ok(result);
        } 
        
        [HttpGet]
        [Authorize]
        [Route("/Room/getRoom/{code}")]
        public async Task<ActionResult<Room>> CreateRoom(string code)
        {
            var result = await _roomService.GetRoomByCode(code);

            return Ok(result);
        }  
        
        [HttpPatch]
        [Authorize]
        [Route("/Room/CloseRoom/{code}")]
        public async Task<ActionResult<bool>> CloseRoom(string code)
        {
            var result = await _roomService.CloseRoom(code);

            return Ok(result);
        }
    }
}
