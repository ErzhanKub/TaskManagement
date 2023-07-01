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
        public async Task<List<MyTask>> GetAllTasksAsync(int userId)
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "SELECT * FROM Tasks WHERE UserId = @UserId";
                var tasks = await connection.QueryAsync<MyTask>(sqlcode, new { userId });
                return (List<MyTask>)tasks;
            }
        }
        public async Task<List<MyTask>> GetAllUserTasksAsync(int userId)
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "SELECT * FROM Tasks";
                var tasks = await connection.QueryAsync<MyTask>(sqlcode, new { userId });
                return (List<MyTask>)tasks;
            }
        }

        /// <summary>
        /// Метод удаление пользователя.
        /// </summary>
        /// <param name="id"></param>
        public async Task RemoveTaskAsync(int id, int userId)
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "DELETE FROM Tasks WHERE Id = @Id AND UserId = @UserId";
                await connection.ExecuteAsync(sqlcode, new { id, userId });
            }
        }
        /// <summary>
        /// Изменение задачи
        /// </summary>
        /// <param Задача="task"></param>
        /// <param Id задачи="id"></param>
        /// <param Id пользователя="userId"></param>
        public async Task EditTaskAsync(MyTask task, int id, int userId)
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "UPDATE Tasks SET NameTask = @NameTask, [Description] = @Description, StartTask = @StartTask, Deadline = @Deadline, UserId = @UserId, [Priority_Id] = @Priority_Id, [Status_Id] = @Status WHERE Id = @Id AND UserId = @UserId";
                await connection.ExecuteAsync(sqlcode, new { task.NameTask, task.Description, task.StartTask, task.Deadline, userId, task.Priority_Id, task.Status, id });
            }
        }

        /// <summary>
        /// Добавить задачу
        /// </summary>
        /// <param Задача="task"></param>
        /// <param Id пользователя="userId"></param>
        public async Task AddTaskAsync(MyTask task, int userId)
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "INSERT INTO Tasks (NameTask, [Description], StartTask, Deadline, UserId, [Priority_Id], [Status_Id]) VALUES (@NameTask, @Description, @StartTask, @Deadline, @UserId, @Priority_Id, @Status)";
                await connection.ExecuteAsync(sqlcode, new { task.NameTask, task.Description, task.StartTask, task.Deadline, userId, task.Priority_Id, task.Status });
            }
        }

    }

}
