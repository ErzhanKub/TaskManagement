using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Meneger.Controllers.DataBase;
using Task_Meneger.Models;

namespace Task_Meneger.Controllers.TaskManager
{
    public class TaskManager
    {
        private readonly int _curentIdUser;
        public TaskManager(int curentIdUser)
        {
            _curentIdUser = curentIdUser;
        }
        public void AddNewTask()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Название: ");
            Console.WriteLine("Описание: ");
            Console.WriteLine("Начало: ");
            Console.WriteLine("Конец: ");
            Console.WriteLine("Приоритет: ");
            Console.WriteLine("Статус: ");
            Console.ResetColor();
            Console.SetCursorPosition(12, 0);
            var nameTask = Console.ReadLine();
            Console.SetCursorPosition(12, 1);
            var description = Console.ReadLine();
            Console.SetCursorPosition(12, 2);
            var StartTask = DateTime.Parse(Console.ReadLine());
            Console.SetCursorPosition(12, 3);
            var Deadline = DateTime.Parse(Console.ReadLine());
            Console.SetCursorPosition(12, 4);
            var Priority_Id = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(12, 5);
            var Status = int.Parse(Console.ReadLine());

            var newtask = new MyTask()
            {
                NameTask = nameTask,
                Description = description,
                StartTask = StartTask,
                Deadline = Deadline,
                Priority_Id = Priority_Id,
                Status = Status
            };
            var datebaseTask = new DataBaseMethodsForTask("Server=.; Database=MyDiary; Trusted_connection=True; Encrypt=Optional");
            datebaseTask.AddTask(newtask, _curentIdUser);
        }
    }
}
