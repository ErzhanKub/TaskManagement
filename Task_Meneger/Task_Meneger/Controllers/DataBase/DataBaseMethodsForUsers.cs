using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Meneger.Controllers.DataBase
{
    public class DataBaseMethodsForUsers
    {
        private readonly string _connection;
        public DataBaseMethodsForUsers(string connectionString)
        {
            _connection = connectionString;
        }
    }
}
