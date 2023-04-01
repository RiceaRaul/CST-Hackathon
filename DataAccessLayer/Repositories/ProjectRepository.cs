using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Models.Projects;
using System.Data;

namespace DataAccessLayer.Repositories
{
    public class ProjectRepository : RepositoryBase, IProjectRepository
    {

        private const string CREATE_PROJECTS = "projects_CreateProjects";
        private const string GET_BY_USERNAME = "projects_GetByUser";
        private const string GET_BY_ID = "project_GetById";
        public ProjectRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public async Task<ProjectDto> CreateProject(CreateProjectRequest request)
        {
            var parameters = new DynamicParameters(new
            {
                title = request.Title,
                description = request.Description,
                author = request.Author,
            });
            var result = await Connection.QueryAsync<ProjectDto>(
                sql: CREATE_PROJECTS,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: Transaction,
                commandTimeout: 20
            );

            return result.First();
        }

        public async Task<IEnumerable<ProjectDto>> GetByUser(string username)
        {
            var parameters = new DynamicParameters(new
            {
                user = username,            
            });
            var result = await Connection.QueryAsync<ProjectDto>(
                sql: GET_BY_USERNAME,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: Transaction,
                commandTimeout: 20
            );

            return result;
        }
        public async Task<IEnumerable<ProjectDto>> GetById(int id)
        {
            var parameters = new DynamicParameters(new
            {
                id = id,
            });
            var result = await Connection.QueryAsync<ProjectDto>(
                sql: GET_BY_ID,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: Transaction,
                commandTimeout: 20
            );

            return result;
        }
    }
}
