using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Models.Authentification;
using Models.Projects;
using Models.Tasks;
using System.Data;

namespace DataAccessLayer.Repositories
{
    public class TaskRepository : RepositoryBase, ITaskRepository
    {
        private readonly string CREATE_TASK = "projects_CreateTask";
        public TaskRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public async Task<TaskDto> CreateTask(TaskCreateRequest request)
        {
            var parameters = new DynamicParameters(new
            {
                name = request.Name,
                description = request.Description,
                type = request.Type,
                resultcode = request.ResultCode,
                projectid = request.ProjectId,
                author = request.Author
            });

            var result = await Connection.QueryAsync<TaskDto>(
                sql: CREATE_TASK,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: Transaction,
                commandTimeout: 20
            );

            return result.First();
        }

    }
}
