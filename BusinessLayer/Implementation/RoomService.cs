using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Models;
using Models.Rooms;

namespace BusinessLayer.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Room> GenerateRoom()
        {
            var resultDto = await _unitOfWork.RoomRepository.GenerateRoom();
            var result = _mapper.Map<Room>(resultDto);
            _unitOfWork.Commit();
            return result;
        }

        public async Task<Room> GetRoomByCode(string roomcode)
        {
            var resultDto = await _unitOfWork.RoomRepository.GetRoomByCode(roomcode);

            var result = _mapper.Map<Room>(resultDto);
            
            return result;
        }  
        public async Task<bool> CloseRoom(string roomcode)
        {
            var result = await _unitOfWork.RoomRepository.CloseRoom(roomcode);

            return result;
        }
    }
}
