﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Meneger.Controllers.DataBase;
using Task_Meneger.Models;
using Task_Meneger.Helpers;
using Task_Meneger.Interface;

namespace Task_Meneger.Controllers.TaskManager
{
    public class TaskManager : ITaskMeneger
    {
        private readonly int _currentIdUser;
        private readonly string _connectionString;
        public TaskManager(int curentIdUser, string connectionString)
        {
            _currentIdUser = curentIdUser;
            _connectionString = connectionString;
        }
        /// <summary>
        /// Создание задачи.
        /// </summary>
        /// <returns></returns>
        private MyTask ToCreateTask()
        {
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("Название: ");
            //Console.WriteLine("Описание: ");
            //Console.WriteLine("Начало: ");
            //Console.WriteLine("Конец: ");
            //Console.WriteLine("Приоритет: ");
            //Console.WriteLine("Статус: ");
            //Console.ResetColor();
            //Console.SetCursorPosition(12, 0);
            //var nameTask = Console.ReadLine();
            //Console.SetCursorPosition(12, 1);
            //var description = Console.ReadLine();
            //Console.SetCursorPosition(12, 2);
            //var StartTask = DateTime.Parse(Console.ReadLine());
            //Console.SetCursorPosition(12, 3);
            //var Deadline = DateTime.Parse(Console.ReadLine());
            //Console.SetCursorPosition(12, 4);
            //var Priority_Id = int.Parse(Console.ReadLine());
            //Console.SetCursorPosition(12, 5);
            //var Status = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(12, 0);
            var nameTask = Helper.ReadString("Название: ");
            Console.SetCursorPosition(12, 1);
            var description = Helper.ReadString("Описание: ");
            Console.SetCursorPosition(12, 2);
            var StartTask = DateTime.Parse(Helper.ReadString("Начало: "));
            Console.SetCursorPosition(12, 3);
            var Deadline = DateTime.Parse(Helper.ReadString("Конец: "));
            Console.SetCursorPosition(12, 4);
            var Priority_Id = Helper.ReadInt("Приоритет: ");
            Console.SetCursorPosition(12, 5);
            var Status = Helper.ReadInt("Статус: ");
            Console.ResetColor();
            var newtask = new MyTask()
            {
                NameTask = nameTask,
                Description = description,
                StartTask = StartTask,
                Deadline = Deadline,
                Priority_Id = Priority_Id,
                Status = Status
            };
            return newtask;
        }
        /// <summary>
        /// Метод для добавлени задачи в базу.
        /// </summary>
        /// <param name="userId"></param>
        public async void AddNewTask()
        {
            ToCreateTask();
            var datebaseTask = new DataBaseMethodsForTask(_connectionString);
            await datebaseTask.AddTaskAsync(ToCreateTask(),_currentIdUser);
        }
        /// <summary>
        /// Удалени задачи.
        /// </summary>
        public async void RemoveTask()
        {
            var datebaseTask = new DataBaseMethodsForTask(_connectionString);
            int idTask = Helper.ReadInt("Введите id задачи: ");
            await datebaseTask.RemoveTaskAsync(idTask,_currentIdUser);
        }
        /// <summary>
        /// Изменение задачи.
        /// </summary>
        public async void EditTask()
        {
            var datebaseTask = new DataBaseMethodsForTask(_connectionString);
            int idTask = Helper.ReadInt("Введите id задачи: ");
            await datebaseTask.EditTaskAsync(ToCreateTask(),idTask,_currentIdUser);
        }
    }
}
