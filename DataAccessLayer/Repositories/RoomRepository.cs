using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Models.Authentification;
using Models.Projects;
using System.Data;

namespace DataAccessLayer.Repositories
{
    public class RoomRepository : RepositoryBase, IRoomRepository
    {
        private const string GENERATE_ROOM = "rooms_generateRoom";

        public RoomRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public async Task<RoomDto> GenerateRoom()
        {
            var result = await Connection.QueryFirstAsync<RoomDto>(
                sql: GENERATE_ROOM,
                commandType: CommandType.StoredProcedure,
                transaction: Transaction,
                commandTimeout: 20
            );

            return result;
        }

        public async Task<RoomDto> GetRoomByCode(string roomcode)
        {
            var parameters = new DynamicParameters(new
            {
                roomid = roomcode,
            });
            var result = await Connection.QueryFirstAsync<RoomDto>(
                sql: "SELECT * FROM rooms where roomcode = @roomid and [status] = 0",
                param:parameters,
                transaction: Transaction,
                commandTimeout: 20
            );

            return result;
        }

        public async Task<bool> CloseRoom(string roomcode)
        {
            var parameters = new DynamicParameters(new
            {
                roomid = roomcode,
            });
            var result = await Connection.ExecuteAsync(
                sql: "UPDATE rooms SET [status] = 1 where roomcode = @roomid",
                param: parameters,
                transaction: Transaction,
                commandTimeout: 20
            );

            return result > 0;
        }
    }
}
