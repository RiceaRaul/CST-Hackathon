using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Models.Authentification;
using System.Data;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {

        private const string CREATE_USER = "users_Create";
        private const string LOGIN_USER = "users_LoginUser";
        private const string GET_BY_USERNAME = "users_getByUsername";

        public UserRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public async Task<UserDto> CreateUser(RegisterRequest request)
        {
            var parameters = new DynamicParameters(new
            {
                username = request.Username,
                password = request.Password,
                email = request.Email,
            });
            var result = await Connection.QueryAsync<UserDto>(
                sql: CREATE_USER,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: Transaction,
                commandTimeout:20
            );

            return result.First();
        }

        public async Task<bool> LoginUser(AuthentificationRequest request)
        {
            var parameters = new DynamicParameters(new
            {
                username = request.Username,
                password = request.Password
            });

            var result = await Connection.ExecuteScalarAsync<bool>(
                sql: LOGIN_USER,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: Transaction,
                commandTimeout: 20
            );

            return result;
        }

        public async Task<UserDto> GetUserDetails(string  username)
        {
            var parameters = new DynamicParameters(new
            {
                username = username,
            });

            var result = await Connection.QueryAsync<UserDto>(
                sql: GET_BY_USERNAME,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: Transaction,
                commandTimeout: 20
            );

            return result.First();
        }
    }
}
