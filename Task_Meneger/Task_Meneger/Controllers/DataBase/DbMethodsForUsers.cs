using Microsoft.EntityFrameworkCore;
using Task_Meneger.Data.EFBase;
using Task_Meneger.Helpers;
using Task_Meneger.Models;

namespace Task_Meneger.Controllers.DataBase
{
    public class DbMethodsForUsers
    {
        private readonly AppDbContext _appDbContext;

        public DbMethodsForUsers(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _appDbContext.Users.ToListAsync();
            return users;
        }
        public async Task<bool> RemoveUserByIdAsync(long id)
        {
            var user = await _appDbContext.FindAsync<User>(id);
            if (user == null)
            {
                return false;
            }
            _appDbContext.Remove(user);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task AddUserAsync(User user)
        {
            await _appDbContext.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateUserByIdAsync(long id)
        {
            var user = await _appDbContext.FindAsync<User>(id);
            if (user == null)
            {
                return false;
            }

            user.Login = Helper.ReadString("Enter login: ");
            user.Password = Helper.ReadString("Enter Password: ");

            _appDbContext.Update(user);
            await _appDbContext.SaveChangesAsync();
            return true;

        }
    }

}
