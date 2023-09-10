using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Task_Meneger.Data.Models;
using Task_Meneger.Data.EFBase;
using Task_Meneger.Helpers;
using Task_Meneger.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Task_Meneger.Controllers.DataBase
{
    public class DbMethodsForTasks
    {
        private readonly AppDbContext _appDbContext;

        public DbMethodsForTasks(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<MyTask>> GetAllTasksAsync()
        {
            var tasks = await _appDbContext.MyTasks.ToListAsync();
            return tasks;
        }

        public async Task<bool> RemoveTaskAsync(long id)
        {
            var task = await _appDbContext.FindAsync<MyTask>(id);
            if (task == null)
            {
                return false;
            }
            _appDbContext.Remove(task);
            await _appDbContext.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateTaskByIdAsync(int id)
        {
            var task = await _appDbContext.FindAsync<MyTask>(id);
            if (task == null)
            {
                return false;
            }
            
            task.Title = Helper.ReadString("Enter name: ");
            task.Description = Helper.ReadString("Enter description: ");
            task.StartTask = DateTime.Parse(Helper.ReadString("Start: "));
            task.Deadline = DateTime.Parse(Helper.ReadString("Finish: "));

            var priorityString = Helper.ReadString("Priority: ");
            task.Priority = (Priority)Enum.Parse(typeof(Priority), priorityString);

            var statusString = Helper.ReadString("Status: ");
            task.Status = (Status)Enum.Parse(typeof(Status), statusString);

            _appDbContext.Update(task);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task AddTaskAsync(MyTask task)
        {
            await _appDbContext.AddAsync(task);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
