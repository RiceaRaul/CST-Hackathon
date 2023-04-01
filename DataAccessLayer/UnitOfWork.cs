using Common.Settings;
using DataAccessLayer.CustomColumnAttribute;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private IDbConnection? _connection;
        private IDbTransaction _transaction;
        private bool _disposed;

        private IUserRepository? _userRepository;
        private IProjectRepository? _projectRepository;
        private ITaskRepository? _taskRepository;
        private IRoomRepository? _roomRepository;
        public UnitOfWork(IOptions<AppSettings> appSettings)
        {
            InitCustomColumn();

            _connection = new SqlConnection("Data Source=91.92.136.222;Initial Catalog=CST;User ID=sa;Password=Relisys123;MultipleActiveResultSets=True");
            _connection.Open();
            _transaction = _connection.BeginTransaction(); 
        }

        private void InitCustomColumn()
        {
            Dapper.SqlMapper.SetTypeMap(typeof(UserDto), new ColumnAttributeTypeMapper<UserDto>());
            Dapper.SqlMapper.SetTypeMap(typeof(ProjectDto), new ColumnAttributeTypeMapper<ProjectDto>());
            Dapper.SqlMapper.SetTypeMap(typeof(TaskDto), new ColumnAttributeTypeMapper<TaskDto>());
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_transaction)); }
        }

        public IProjectRepository ProjectRepository
        {
            get { return _projectRepository ?? (_projectRepository = new ProjectRepository(_transaction)); }
        }

        public ITaskRepository TaskRepository
        {
            get { return _taskRepository ?? (_taskRepository = new TaskRepository(_transaction)); }
        }   
        public IRoomRepository RoomRepository
        {
            get { return _roomRepository ?? (_roomRepository = new RoomRepository(_transaction)); }
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void resetRepositories()
        {
            _userRepository = null;
            _projectRepository = null;
            _taskRepository = null;
            _roomRepository = null;
        }

        public void Commit()
        {
            resetRepositories();
            try
            {
                _transaction!.Commit();
            }
            catch
            {
                _transaction!.Rollback();
                throw;
            }
            finally
            {
                _transaction!.Dispose();
                _transaction = _connection!.BeginTransaction();           
            }
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null!;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }
        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
