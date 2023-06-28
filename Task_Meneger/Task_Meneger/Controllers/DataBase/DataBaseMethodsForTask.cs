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
    /// <summary>
    /// Класс для работы с базой данных для задач.
    /// </summary>
    public class DataBaseMethodsForTask
    {
        /// <summary>
        /// Строка подключения.
        /// </summary>
        private readonly string _connection;
        public DataBaseMethodsForTask(string connectionString)
        {
            _connection = connectionString;
        }
        /// <summary>
        /// Метод для получения всех задач.
        /// </summary>
        /// <returns> List<Users>. </returns>
        public List<MyTask> GetAllTask()
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "SELECT * FROM Tasks";
                var tasks = connection.Query<MyTask>(sqlcode);
                return (List<MyTask>)tasks;
            }
        }
       /// <summary>
       /// Метод удаление пользователя.
       /// </summary>
       /// <param name="id"></param>
        public void DeleteTask(int id)
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = $"DELETE FROM Tasks WHERE Id = {id}";
                connection.Execute(sqlcode, new {Id = id});
            }
        }
        public void EditTask(MyTask task, int id)
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = $"UPDATE Tasks SET NameTask = N'{task.NameTask}', [Description] = N'{task.Description}', " +
                    $"StartTask = '{task.StartTask}', Deadline = '{task.Deadline}', UserId = 1, " +
                    $"[Priority_Id] = {task.Priority_Id}, [Status_Id] = {task.Status} WHERE Id = {id}";
                connection.Execute(sqlcode, new {task.NameTask,task.Description,id});
            }
        }
        public void AddTask(MyTask task, int id)
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = $"INSERT INTO Tasks " +
                    $"VALUES (N'{task.NameTask}',N'{task.Description}','{task.StartTask}','{task.Deadline}',{id},{task.Priority_Id},{task.Status})";
                connection.Execute(sqlcode, new {task.NameTask,task.Description,task.StartTask,task.Deadline,id,task.Priority_Id,task.Status});
            }
        }
    }
}
