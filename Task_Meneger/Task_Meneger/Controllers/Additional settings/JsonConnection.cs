﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Meneger.Helpers;
using Task_Meneger.Models;

namespace Task_Meneger.Controllers.Additional_settings
{
    public class JsonConnection
    {
        public void ExporJson(List<MyTask> myTasks)
        {
            string json = JsonConvert.SerializeObject(myTasks, Formatting.Indented);
            var nameFile = Helper.ReadString("Введите название файла: ");
            File.WriteAllText($"{nameFile}", json);
        }
        public List<MyTask> ImportJson(string nameFile)
        {
            string json = File.ReadAllText($"{nameFile}");
            var tasksList = JsonConvert.DeserializeObject<List<MyTask>>(json);
            if(tasksList == null)
            {
                Console.WriteLine("Пустой файл!");
            }
            return tasksList;
        }
    }
}