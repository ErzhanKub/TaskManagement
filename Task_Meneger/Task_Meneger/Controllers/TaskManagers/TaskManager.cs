using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Meneger.Models;

namespace Task_Meneger.Controllers.TaskManager
{
    public class TaskManager
    {
        public void AddNewTask(MyTask task)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Создание задачи");
            Console.ResetColor();
            task = new MyTask()
            {
                NameTask = "Домашка",
                Description = "Сделать до понедельника",
                StartTask = DateTime.Parse("28.06.2023"),
                Deadline = DateTime.Parse("29.06.2023"),
                Priority_Id = 1,
                Status = 1
            };
            while(true)
            {
                Console.WriteLine("Название: ");
                Console.WriteLine("Описание: ");
                Console.WriteLine("Начало: ");
                Console.WriteLine("Конец: ");
                Console.WriteLine("Приоритет: ");
                Console.WriteLine("Статус: ");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
