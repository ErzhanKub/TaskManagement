﻿using Dapper;
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
        public async Task<List<User>> GetAllUsersAsync()
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "SELECT * FROM Users";
                var users = await connection.QueryAsync<User>(sqlcode);
                return (List<User>)users;
            }
        }
        /// <summary>
        /// Метод для удаления пользователя.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveUserAsync(long id)
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "DELETE FROM Users WHERE Id = @Id";
                await connection.ExecuteAsync(sqlcode, new { id });
            }
        }

        /// <summary>
        /// Метод для добавления нового пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task AddUserAsync(User user)
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "INSERT INTO Users (FirstName, LastName, [Login], [Password], Email, Phone) VALUES (@FirstName, @LastName, @Login, @Password, @Email, @Phone)";
                await connection.ExecuteAsync(sqlcode, new { user.FirstName, user.LastName, user.Login, user.Password, user.Email, user.Phone });
            }
        }

        /// <summary>
        /// Метод для изменения пользователя
        /// </summary>
        /// <param User="user"></param>
        /// <param Id="id"></param>
        /// <returns></returns>
        public async Task EditUserAsync(User user, long id)
        {
            using var connection = new SqlConnection(_connection);
            {
                var sqlcode = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, [Login] = @Login, [Password] = @Password, Email = @Email, Phone = @Phone WHERE Id = @Id";
                await connection.ExecuteAsync(sqlcode, new { user.FirstName, user.LastName, user.Login, user.Password, user.Email, user.Phone, id });
            }
        }
        /// <summary>
        /// Метод sql для получения пользователя по Login
        /// </summary>
        /// <param name="name"></param>
        public async Task<User> GetUserByLogin(string login)
        {
            using (var connection = new SqlConnection(_connection))
            {
                var sqlcode = "SELECT * FROM Users WHERE Login = @login";
                return await connection.QueryFirstOrDefaultAsync<User>(sqlcode, new { login });
            }
        }
    }

}
