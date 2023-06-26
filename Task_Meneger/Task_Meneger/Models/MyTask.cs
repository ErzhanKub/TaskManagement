using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Meneger.Enums;

namespace Task_Meneger.Models
{
    public class MyTask
    {
        public int Id { get; private set; }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Пустое название задачи.", nameof(value));
                }
                _name = value;
            }
        }
        public string Description { get; set; } = string.Empty;    
        public DateTime StartTask { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public DateTime Deadline { get; set; }
        public List<string>? Tags { get; set; }

        public override string ToString() => $"";
        
    }
}
