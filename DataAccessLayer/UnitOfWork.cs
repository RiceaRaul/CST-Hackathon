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
        private IDbTransaction? _transaction;
        private bool _disposed;

        private IUserRepository _userRepository;
        public UnitOfWork(IOptions<AppSettings> appSettings)
        {
            InitCustomColumn();

            _connection = new SqlConnection("Data Source=91.92.136.222;Initial Catalog=CST;User ID=sa;Password=Relisys123;");
            _connection.Open();
            _transaction = _connection.BeginTransaction(); 
        }

        private void InitCustomColumn()
        {
            Dapper.SqlMapper.SetTypeMap(typeof(UserDto), new ColumnAttributeTypeMapper<UserDto>());
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_transaction)); }
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void resetRepositories()
        {
            _userRepository = null;
        }

        public void Commit()
        {
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
                resetRepositories();
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
                        _transaction = null;
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
