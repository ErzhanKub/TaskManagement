using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Meneger.Interface
{
    interface IUserManagement
    {
        Task RemoveUserAsync();
        Task GetAllUsersAsync();
        Task UpdateUserAsync();
        Task AddUserAsync();
    }
}
