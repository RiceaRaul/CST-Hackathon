using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Models.ErrorHandling;
using Models.Tasks;
using System.Data.SqlClient;
using System.Net;

namespace BusinessLayer.Implementation
{
    internal class TaskService : ITaskService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public TaskService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TaskModel> CreateTask(TaskCreateRequest request)
        {
            try
            {
                var result = await _unitOfWork.TaskRepository.CreateTask(request);
                var resultMapped = _mapper.Map<TaskModel>(result);

                _unitOfWork.Commit();
                return resultMapped;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 500001)
                {
                    throw new ApiErrorException(ex.Message, HttpStatusCode.BadRequest);
                }
                else
                {
                    throw new ApiErrorException(ex.Message);
                }
            }
        }
    }
}
