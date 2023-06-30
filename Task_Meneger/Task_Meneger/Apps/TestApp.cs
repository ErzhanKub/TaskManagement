using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Meneger.Controllers.Additional_settings;
using Task_Meneger.Controllers.DataBase;
using Task_Meneger.Controllers.TaskManager;
using Task_Meneger.Models;

namespace Task_Meneger.Apps
{
    public class TestApp
    {
        public void Start()
        {
            var af = new Authorization();
            af.ReadPassword();
            var task = new TaskManager(5);
            task.AddNewTask();
        }
    }
}
