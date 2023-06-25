using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Meneger.Models
{
    public class User
    {
        public int Id { get; private set; }
        private string _firstname;
        public string FirstName
        {
            get => _firstname;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Имя не можеть быть пустым", nameof(value));
                }
                _firstname = value;
            }
        }

    }
}
