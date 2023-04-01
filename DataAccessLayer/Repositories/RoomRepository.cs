using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Models.Authentification;
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
    }
}
