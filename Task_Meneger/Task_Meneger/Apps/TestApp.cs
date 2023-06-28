using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Meneger.Controllers.DataBase;
using Task_Meneger.Models;

namespace Task_Meneger.Apps
{
    public class TestApp
    {
        public void Start()
        {
            #region Проверка база.
            //var test = new DataBaseMethodsForUsers("Server=.; Database=MyDiary; Trusted_connection=True; Encrypt=Optional");

            //var result = test.GetAllUsers();
            //foreach (var task in result)
            //{
            //    Console.WriteLine($"Имя: {task.FirstName} | Фамилия: {task.LastName} | Login: {task.Login} | Password: {task.Password} ");
            //}

            //var res = test.DeleteUser(3);
            //Console.WriteLine(res);
            //var newuser = new User()
            //{
            //    FirstName = "Erzhan",
            //    LastName = "Kubanchbek",
            //    Login = "ErzhanKub",
            //    Password = 1234,
            //    Email = "avazov.erjan@gmail.com",
            //    Phone = "0509807580"
            //};
            //var res = test.AddUser(newuser);
            //Console.WriteLine(res);
            #endregion
            var test = new DataBaseMethodsForTask("Server=.; Database=MyDiary; Trusted_connection=True; Encrypt=Optional");
            test.DeleteTask(3);
            var res = test.GetAllTask();
            foreach (var item in res)
            {
                Console.WriteLine(item.Priority_Id);
            }
            var test2 = new DataBaseMethodsForUsers("Server=.; Database=MyDiary; Trusted_connection=True; Encrypt=Optional");

            var result = test2.GetAllUsers();
            foreach (var task in result)
            {
                Console.WriteLine($"Имя: {task.FirstName} | Фамилия: {task.LastName} | Login: {task.Login} | Password: {task.Password} ");
            }

            //var task = new MyTask()
            //{
            //    NameTask = "Домашка",
            //    Description = "Сделать до понедельника",
            //    StartTask = DateTime.Parse("28.06.2023"),
            //    Deadline = DateTime.Parse("29.06.2023"),
            //    Priority_Id = 1,
            //    Status = 1
            //};
            //while (true)
            //{
            //    Console.ForegroundColor = ConsoleColor.Yellow;
            //    Console.WriteLine("Название: ");
            //    Console.WriteLine("Описание: ");
            //    Console.WriteLine("Начало: ");
            //    Console.WriteLine("Конец: ");
            //    Console.WriteLine("Приоритет: ");
            //    Console.WriteLine("Статус: ");
            //    Console.ResetColor();
            //    Console.SetCursorPosition(12, 0);
            //    var nameTask = Console.ReadLine();
            //    Console.SetCursorPosition(12, 1);
            //    var description = Console.ReadLine();
            //    Console.SetCursorPosition(12, 2);
            //    var StartTask = DateTime.Parse(Console.ReadLine());
            //    Console.SetCursorPosition(12, 3);
            //    var Deadline = DateTime.Parse(Console.ReadLine());
            //    Console.SetCursorPosition(12, 4);
            //    var Priority_Id = int.Parse(Console.ReadLine());
            //    Console.SetCursorPosition(12, 5);
            //    var Status = int.Parse(Console.ReadLine());

            //    var newtask = new MyTask()
            //    {
            //        NameTask = nameTask,
            //        Description = description,
            //        StartTask = StartTask,
            //        Deadline = Deadline,
            //        Priority_Id = Priority_Id,
            //        Status = Status
            //    };
            //    Console.ReadKey();
            //    Console.Clear();
            //}
        }

    }
}
