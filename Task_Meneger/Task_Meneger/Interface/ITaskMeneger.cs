using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Meneger.Interface
{
    interface ITaskMeneger
    {
        public void AddTask() { }
        public void RemoveTask() { }
        public void EditTask() { }
        public void GetTasks() { }
    }
}
