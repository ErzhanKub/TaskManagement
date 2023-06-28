using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Meneger.Models;

namespace Task_Meneger.Controllers.DataBase
{
    /// <summary>
    /// Класс для работы с базой данных.
    /// </summary>
    public class DataBaseMethodsForUsers
    {
        /// <summary>
        /// Строка подключения.
        /// </summary>
        private readonly string _connection;
        /// <summary>
        /// Созадение обьекта класса и передача строки подк.
        /// </summary>
        /// <param name="connectionString"></param>
        public DataBaseMethodsForUsers(string connectionString)
        {
            _connection = connectionString;
        }
        /// <summary>
        /// Метод для получения всех пользователей.
        /// </summary>
        /// <returns> List<Users>. </returns>
        public List<User> GetAllUsers()
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "SELECT * FROM Users";
                var users = connection.Query<User>(sqlcode);
                return (List<User>)users;
            }
        }
       /// <summary>
       /// Метод для удаления пользователя.
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public bool DeleteUser(long id)
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = $"DELETE FROM Users WHERE Id = {id}";
                connection.Execute(sqlcode);
                return true;
            }
        }
        /// <summary>
        /// Метод для добавления нового пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(User user)
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = $"INSERT Users VALUES (N'{user.FirstName}',N'{user.LastName}',N'{user.Login}',{user.Password},N'{user.Email}',N'{user.Phone}') ";
                connection.Execute(sqlcode);
                return true;
            }
        }
    }
}
