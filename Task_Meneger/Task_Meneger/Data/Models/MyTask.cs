
using System.ComponentModel.DataAnnotations.Schema;
using Task_Meneger.Data.Enums;
using Task_Meneger.Models;

namespace Task_Meneger.Data.Models
{
    public class MyTask
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        [ForeignKey("User")]
        public long UserId { get; set; }
        public User? User { get; set; }
        public DateTime StartTask { get; set; }
        public DateTime Deadline { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
    }
}
