using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Meneger.Data.Models;
using Task_Meneger.Models;

namespace Task_Meneger.Data.EFBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base(new DbContextOptionsBuilder<AppDbContext>()
       .UseSqlServer("Server=.; Database=MyDiary; Trusted_Connection=Yes; Encrypt=Optional")
       .Options)
        {
        } // TODO: Добавить возможность брать строку подключения через конф.
        public DbSet<MyTask> MyTasks => Set<MyTask>();
        public DbSet<User> Users => Set<User>();
    }
}
