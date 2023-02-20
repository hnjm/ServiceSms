using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
namespace ServiceSms.Database
{
    public class DbRepository
    {
    }
 

public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }

    public class Repository<T> : IRepository<T>
    {
        private readonly IDbConnection _dbConnection;

        public Repository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            string sql = "SELECT * FROM " + typeof(T).Name;
            return await _dbConnection.QueryAsync<T>(sql);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            string sql = "SELECT * FROM " + typeof(T).Name + " WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<T>(sql, new { Id = id });
        }

        public async Task<int> AddAsync(T entity)
        {
            string sql = "INSERT INTO " + typeof(T).Name + " VALUES (@Name, @Age)";
            return await _dbConnection.ExecuteAsync(sql, entity);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            string sql = "UPDATE " + typeof(T).Name + " SET Name = @Name, Age = @Age WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, entity);
        }

        public async Task<int> DeleteAsync(T entity)
        {
            string sql = "DELETE FROM " + typeof(T).Name + " WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, entity);
        }
    }

}
