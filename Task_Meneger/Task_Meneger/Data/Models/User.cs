using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Meneger.Data.Models;

namespace Task_Meneger.Models
{
    public class User
    {
        public long Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public List<MyTask>? Tasks { get; set; }
    }
}
