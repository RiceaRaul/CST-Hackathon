using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Models;
using Models.Authentification;
using Models.ErrorHandling;
using System.Data.SqlClient;
using System.Net;
using System.Security.Claims;

namespace BusinessLayer.Implementation
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly IJwtService _jwtService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthentificationService(IJwtService jwtService,IUnitOfWork unitOfWork,IMapper mapper)
        {
            _jwtService= jwtService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuthentificationResponse?> Authentificate(AuthentificationRequest request)
        {
            try
            {
                var userValidate = await _unitOfWork.UserRepository.LoginUser(request);
                _unitOfWork.Commit();

                var claim = CreateClaim(request);
                if (claim == null)
                {
                    return null;
                }

                return _jwtService.CreateJwt(claim);
            }
            catch(SqlException ex) {
                if(ex.Number == 500001)
                {
                    throw new ApiErrorException(ex.Message, HttpStatusCode.NotFound);
                }
                else
                {
                    throw new ApiErrorException(ex.Message, HttpStatusCode.BadRequest);
                }
              
            }
        } 
        
        public async Task<User> GetUserDetails(string username)
        {
            try
            {
                var userValidate = await _unitOfWork.UserRepository.GetUserDetails(username);
                _unitOfWork.Commit();
                var user = _mapper.Map<User>(userValidate);

                return user;
            }
            catch(SqlException ex) {
                if(ex.Number == 500001)
                {
                    throw new ApiErrorException(ex.Message, HttpStatusCode.NotFound);
                }
                else
                {
                    throw new ApiErrorException(ex.Message, HttpStatusCode.BadRequest);
                }
              
            }
        }

        private Claim[] CreateClaim(AuthentificationRequest request)
        {
            var listClaim = new List<Claim>
            {
                new Claim(ClaimTypes.Name,request.Username)
            };

            return listClaim.ToArray();
        }

        public async Task<User> CreateUser(RegisterRequest request)
        {
            try
            {
                var result = await _unitOfWork.UserRepository.CreateUser(request);
                _unitOfWork.Commit();

                var response = _mapper.Map<User>(result);

                return response;
            }
            catch(Exception ex) {
                throw new ApiErrorException(ex.Message, HttpStatusCode.BadRequest);
            }
         
        }
    }
}
