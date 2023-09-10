using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Meneger.Interface
{
    interface ITaskMenegement
    {
        Task AddTaskAsync();
        Task RemoveTaskAsync();
        Task UpdateTaskAsync();
        Task GetAllTasksAsync();
    }
}
