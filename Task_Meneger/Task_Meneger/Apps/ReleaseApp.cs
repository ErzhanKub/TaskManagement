using Microsoft.Extensions.Configuration;
using Task_Meneger.Controllers.DataBase;
using Task_Meneger.Helpers;
using Task_Meneger.Models;

namespace Task_Meneger.Apps
{
    public class ReleaseApp
    {
        /// <summary>
        /// Строка подключения.
        /// </summary>
        private readonly  string _connectionString;
        /// <summary>
        /// Созадение обьекта класса и передача строки подк.
        /// </summary>
        /// <param name="database"></param>
        public ReleaseApp(string connection)
        {
           _connectionString= connection;
        }
        /// <summary>
        /// Класс Start для вывода в консоль
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
            Console.WriteLine("Welcome to Task Manager!");
            Console.WriteLine("=======================");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add a new user");
                Console.WriteLine("2. Delete a user");
                Console.WriteLine("3. View all users");
                Console.WriteLine("4. Search user by login");
                Console.WriteLine("0. Exit");
                Console.WriteLine("=======================");
                Console.WriteLine();


                var keyInfo = Console.ReadKey();
                Console.WriteLine();

                switch (keyInfo.KeyChar)
                {
                    case '4':
                        await GetUserByLoginMenu();
                        break;
                    case '1':
                        await AddUserMenu();
                        break;
                    case '2':
                        await DeleteUserMenu();
                        break;
                    case '3':
                        await GetAllUsersMenu();
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Метод добавление пользователя в консоли
        /// </summary>
        private async Task AddUserMenu()
        {
            Console.WriteLine("Add a new User:");
            Console.WriteLine("===============");

            var user = new User();


            user.FirstName = Helper.ReadString("First name: ");

            Console.Write("LastName: ");
            user.LastName = Console.ReadLine();

            Console.Write("Login: ");
            user.Login = Console.ReadLine();

            Console.Write("Password (only numbers): ");
            user.Password = Console.ReadLine();

            Console.Write("Email: ");
            user.Email = Console.ReadLine();

            Console.Write("Phone: ");
            user.Phone = Console.ReadLine();
            var data = new DataBaseMethodsForUsers(_connectionString);
            await data.AddUserAsync(user);
            Console.WriteLine("User added successfully!");
        }
        /// <summary>
        /// Метод поиска пользователя по логину в консоли
        /// </summary>
        /// <returns></returns>
        private async Task GetUserByLoginMenu()
        {
            Console.Write("Enter user name: ");
            var name = Console.ReadLine();
            var data = new DataBaseMethodsForUsers(_connectionString);
            var user = await data.GetUserByLogin(name);

            if (user == null)
            {
                Console.WriteLine("User not found.");
            }
            else
            {
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"FirstName: {user.FirstName}");
                Console.WriteLine($"LastName: {user.LastName}");
                Console.WriteLine($"Login: {user.Login}");
                Console.WriteLine($"Password: {user.Password}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Phone: {user.Phone}");
            }
        }
        /// <summary>
        /// Метод получение всех пользователей в консоли
        /// </summary>
        /// <returns></returns>
        private async Task GetAllUsersMenu()
        {
            var data = new DataBaseMethodsForUsers(_connectionString);
            var users = await data.GetAllUsersAsync();

            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"FirstName: {user.FirstName}");
                Console.WriteLine($"LastName: {user.LastName}");
                Console.WriteLine($"Login: {user.Login}");
                Console.WriteLine($"Password: {user.Password}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Phone: {user.Phone}");
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Метод удаления пользователя в консоли
        /// </summary>
        /// <returns></returns>
        private async Task DeleteUserMenu()
        {
            Console.Write("Enter user login to delete: ");
            string login = Console.ReadLine();
            var data = new DataBaseMethodsForUsers(_connectionString);
            var user = await data.GetUserByLogin(login);

            if (user != null)
            {
                await data.RemoveUserAsync(user.Id);

                Console.WriteLine("User deleted successfully");
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }
    }
}

