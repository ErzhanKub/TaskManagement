using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Meneger.Controllers.UserManagers
{
    public class UserManager
    {
        private readonly int _currentIdUser;
        private readonly string _connectionString;
        public UserManager(int curentIdUser, string connectionString)
        {
            _currentIdUser = curentIdUser;
            _connectionString = connectionString;
        }
    }
}
