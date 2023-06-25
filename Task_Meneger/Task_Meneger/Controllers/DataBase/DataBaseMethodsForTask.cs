using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Task_Meneger.Models;

namespace Task_Meneger.Controllers.DataBase
{
    public class DataBaseMethodsForTask
    {
        private readonly string _connection;
        public DataBaseMethodsForTask(string connectionString)
        {
            _connection = connectionString;
        }

        public async Task<IEnumerable<MyTask>> GetAllTask() //TODO: Доработать
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "";
                var tasks = await connection.QueryAsync<MyTask>(sqlcode);
                return tasks;
            }
        }
        public async Task AddTask() //TODO: Доработать
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "";
                await connection.ExecuteAsync(sqlcode);
            }
        }
        public async Task DeleteTask(int id) //TODO: Доработать
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "";
                await connection.ExecuteAsync(sqlcode, new {Id = id});
            }
        }
        public async Task EditTask(MyTask task, int id) //TODO: Доработать
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "";
                await connection.ExecuteAsync(sqlcode, new {task.Name,task.Description,id});
            }
        }
    }
}
