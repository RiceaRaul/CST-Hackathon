using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
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

            return result;
        }
    }
}
