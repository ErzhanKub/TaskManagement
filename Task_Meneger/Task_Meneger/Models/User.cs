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
        private string _lastname;
        private string _login;
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
        public string LastName
        {
            get => _lastname;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Фамилия не может быть пустым", nameof(value));
                }
                _lastname = value;
            }
        }
        public string Login
        {
            get => _login;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Логин не может быть пустым", nameof(value));
                }
                _login = value;
            }
        }
        public int Password { get;  set; }//Закрыть доступ
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public override string ToString()
        {
            return base.ToString(); //Изменить
        }

    }
}
