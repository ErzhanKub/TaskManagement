
using Task_Meneger.Controllers.DataBase;
using Task_Meneger.Data.EFBase;
using Task_Meneger.Data.Enums;
using Task_Meneger.Services.TaskManagers;
using Task_Meneger.Services.UserManagers;

namespace Task_Meneger.Apps
{
    public class ReleaseApp
    {
        private readonly AppDbContext _appDbContext;

        public ReleaseApp(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Task management!");
                Console.WriteLine("=======================");
                Console.WriteLine();
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Users Settings");
                Console.WriteLine("2. Tasks settings");
                Console.WriteLine("0. Exit");
                Console.WriteLine("=======================");
                Console.WriteLine();

                var input = Console.ReadLine();
                if (int.TryParse(input, out int option))
                {
                    switch ((OptionForMain)option)
                    {
                        case OptionForMain.ProfileSettings: await UsersSettings(); break;
                        case OptionForMain.TaskSettings: await TasksSettings(); break;
                        case OptionForMain.Exit: return;
                        default: Console.WriteLine("Invalid option. Try again."); break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
                Console.WriteLine();
            }

        }
        public async Task UsersSettings()
        {
            var dbUsers = new DbMethodsForUsers(_appDbContext);
            var userManager = new UserManagement(dbUsers);
            await userManager.Start();
        }
        public async Task TasksSettings()
        {
            var dbTask = new DbMethodsForTasks(_appDbContext);
            var taskManager = new TaskManagement(dbTask);
            await taskManager.Start();
        }
    }
}

