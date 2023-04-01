using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Models;
using Models.ErrorHandling;
using Models.Projects;
using Models.Tasks;
using System.Data.SqlClient;
using System.Net;

namespace BusinessLayer.Implementation
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProjectService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Project> CreateProject(CreateProjectRequest request)
        {
            try
            {
                var result = await _unitOfWork.ProjectRepository.CreateProject(request);
                var resultMapped  = _mapper.Map<Project>(result);
                
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
        
        public async Task<IEnumerable<Project>> GetByUser(string username)
        {
            try
            {
                var result = await _unitOfWork.ProjectRepository.GetByUser(username);
                var resultMapped  = _mapper.Map<IEnumerable<Project>>(result);
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
        public async Task<IEnumerable<Project>> GetById(int id)
        {
            try
            {
                var result = await _unitOfWork.ProjectRepository.GetById(id);
                var resultMapped = _mapper.Map<IEnumerable<Project>>(result);
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
