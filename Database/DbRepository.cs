using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using ServiceSms.Model;
using System.Data.SqlClient;

namespace ServiceSms.Database
{
    public class DbRepository
    {
    }
 

public interface IRepository
    {
       // Task<IEnumerable<T>> GetAllAsync();
       // Task<T> GetByIdAsync(int id);
       Task<bool> Send(List<Sms> sms);
       
    }

    public class Repository : IRepository
    {
        private readonly IDbConnection _dbConnection;

        public Repository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        //public async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    string sql = "SELECT * FROM Message";
        //    return await _dbConnection.QueryAsync<T>(sql);
        //}

        //public async Task<T> GetByIdAsync(int id)
        //{
        //    string sql = "SELECT * FROM Message WHERE Id = @Id";
        //    return await _dbConnection.QueryFirstOrDefaultAsync<T>(sql, new { Id = id });
        //}

        public async  Task<bool> Send(List<Sms> sms)
        {
            using (var con = new SqlConnection("Data Source=(localdb)\\localdbdemo;Integrated Security=True"))
            {
                //ID ,    SendTo ,	Vendor , NumOfLine , MessageBody ,	RecTime
                {
                    string sql = "INSERT INTO Message(ID, SendTo, RecTime, Vendor, NumOfLine, MessageBody)" +
                           "VALUES(@ID,@SendTo,@RecTime ,@Vendor, @NumOfLine,@MessageBody)";
                    con.Open();
                    //var test = con.Query<Sms>("select * from Message");
                    foreach (Sms smsItem in sms)
                    {                      
                        try
                        {
                            int rowsAffected =await con.ExecuteAsync(sql, smsItem);
                        }
                        catch
                        {
                            
                        }
                    }
                    con.Close();
                }
                return true ;
            }
        }

       

       
    }

}
