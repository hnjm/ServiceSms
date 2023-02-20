using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using ServiceSms.Model;

namespace ServiceSms.Database
{
    public class DbRepository
    {
    }
 

public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void Add(List<Sms> sms);
       
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

        public  void Add(List<Sms> sms)
        {
            foreach (Sms smsItem in sms)
            {
                string sql = "INSERT INTO  VALUES (@Name, @Age)";
                 _dbConnection.ExecuteAsync(sql, sms);
            }
            
        }

       

       
    }

}
