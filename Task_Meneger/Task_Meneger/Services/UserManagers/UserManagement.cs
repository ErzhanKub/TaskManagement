using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Meneger.Controllers.DataBase;
using Task_Meneger.Data.EFBase;
using Task_Meneger.Data.Enums;
using Task_Meneger.Helpers;
using Task_Meneger.Interface;
using Task_Meneger.Models;

namespace Task_Meneger.Services.UserManagers
{
    public class UserManagement : IUserManagement
    {
        private readonly DbMethodsForUsers _dbUser;
        public UserManagement(DbMethodsForUsers dataBaseMethodsForUsers)
        {
            _dbUser = dataBaseMethodsForUsers;
        }

        public async Task Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("User settings");
                Console.WriteLine("=======================");
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add user");
                Console.WriteLine("2. Remove user");
                Console.WriteLine("3. View all users");
                Console.WriteLine("4. Update user");
                Console.WriteLine("0. Exit");
                Console.WriteLine("=======================");
                Console.WriteLine();

                var input = Console.ReadLine();
                if (int.TryParse(input, out int option))
                {
                    switch ((OptionForUM)option)
                    {
                        case OptionForUM.AddUser: await AddUserAsync(); break;
                        case OptionForUM.RemoveUser: await RemoveUserAsync(); break;
                        case OptionForUM.ViewAllUsers: await GetAllUsersAsync(); break;
                        case OptionForUM.UpdateUser: await UpdateUserAsync(); break;
                        case OptionForUM.Exit: return;
                        default: Console.WriteLine("Invalid option. Try again."); Console.ReadKey(); break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again."); Console.ReadKey();
                }
                Console.WriteLine();
            }
        }

        public async Task AddUserAsync()
        {
            Console.Clear();
            Console.WriteLine("Add user:");
            Console.WriteLine("===============");

            var login = Helper.ReadString("Login: ");
            var password = Helper.ReadString("Paswword: ");
            var newUser = new User()
            {
                Login = login,
                Password = password
            };

            await _dbUser.AddUserAsync(newUser);
            Helper.PositiveResponse("User added successfully!");
        }

        public async Task GetAllUsersAsync()
        {
            Console.Clear();
            Console.WriteLine("View all users:");
            Console.WriteLine("===============");

            var users = await _dbUser.GetAllUsersAsync();

            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id} | Login: {user.Login} | Password: {user.Password}");
                if (user.Tasks != null)
                {
                    foreach (var task in user.Tasks)
                    {
                        Console.WriteLine($"Id: {task.Id} | Title: {task.Title}" +
                       $"\nDescription: {task.Description} | User: {task.User}" +
                       $"\nStart task: {task.StartTask} | Deadline: {task.Deadline}" +
                       $"\nStatus: {task.Status} |Priority: {task.Priority}");
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Click to continue");
            Console.ReadKey();
        }

        public async Task RemoveUserAsync()
        {
            Console.Clear();
            Console.WriteLine("Remove user:");
            Console.WriteLine("===============");

            var id = Helper.ReadInt("Enter id user: ");
            var result = await _dbUser.RemoveUserByIdAsync(id);
            if (result == true)
            {
                Helper.PositiveResponse("User deleted successfully!");
            }
            else
            {
                Helper.NegativeResponse("User is not found, try again!");
            }
        }

        public async Task UpdateUserAsync()
        {
            Console.Clear();
            Console.WriteLine("Update user:");
            Console.WriteLine("===============");
            int id = Helper.ReadInt("Enter id user: ");
            var result = await _dbUser.UpdateUserByIdAsync(id);
            if(result == true)
            {
                Helper.PositiveResponse("User data has been successfully changed!");
            }
            else
            {
                Helper.NegativeResponse("User is not found, try again!");
            }
        }
    }
}
