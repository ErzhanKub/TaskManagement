using Task_Meneger.Controllers.DataBase;
using Task_Meneger.Helpers;
using Task_Meneger.Interface;
using Task_Meneger.Data.Models;
using Task_Meneger.Data.Enums;
using Task_Meneger.Data.EFBase;

namespace Task_Meneger.Services.TaskManagers
{
    public class TaskManagement : ITaskMenegement
    {
        private readonly DbMethodsForTasks _dbTask;

        public TaskManagement(DbMethodsForTasks dbTask)
        {
            _dbTask = dbTask;
        }

        public async Task Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Task settings");
                Console.WriteLine("=======================");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add task.");
                Console.WriteLine("2. Remove task.");
                Console.WriteLine("3. View all tasks.");
                Console.WriteLine("4. Update task.");
                Console.WriteLine("0. Exit.");
                Console.WriteLine("=======================");
                Console.WriteLine();

                var input = Console.ReadLine();
                if (int.TryParse(input, out int option))
                {
                    switch ((OptionForTM)option)
                    {
                        case OptionForTM.AddTask: await AddTaskAsync(); break;
                        case OptionForTM.RemoveTask: await RemoveTaskAsync(); break;
                        case OptionForTM.ViewAllTasks: await GetAllTasksAsync(); break;
                        case OptionForTM.UpdateTask: await UpdateTaskAsync(); break;
                        case OptionForTM.Exit: return;
                        default: Console.WriteLine("Invalid option. Try again."); Console.ReadKey(); break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again."); Console.ReadKey();
                }
                Console.WriteLine();
            }
        }


        public async Task AddTaskAsync() //TODO: User/UserId разобратся что как.
        {
            Console.Clear();
            Console.WriteLine("Add task:");
            Console.WriteLine("===============");
            var title = Helper.ReadString("Title: ");
            var description = Helper.ReadString("Description: ");
            var startTask = DateTime.Parse(Helper.ReadString("StartTask: "));
            var deadline = DateTime.Parse(Helper.ReadString("Deadline: "));
            var priorityString = Helper.ReadString("Priority: ");
            var priority = (Priority)Enum.Parse(typeof(Priority), priorityString);
            var statusString = Helper.ReadString("Status: ");
            var status = (Status)Enum.Parse(typeof(Status), statusString);
            var newTask = new MyTask()
            {
                Title = title,
                Description = description,
                StartTask = startTask,
                Deadline = deadline,
                Priority = priority,
                Status = status
            };
            await _dbTask.AddTaskAsync(newTask);
            Helper.PositiveResponse("Task added successfully!");
        }

        public async Task RemoveTaskAsync()
        {
            Console.Clear();
            Console.WriteLine("Remove task:");
            Console.WriteLine("===============");
            int id = Helper.ReadInt("Enter id task: ");
            var result = await _dbTask.RemoveTaskAsync(id);
            if (result == true)
            {
                Helper.PositiveResponse("The task was successfully deleted!");
            }
            else
            {
                Helper.NegativeResponse("Task not found, try again!");
            }
        }

        public async Task UpdateTaskAsync()
        {
            Console.Clear();
            Console.WriteLine("Update task:");
            Console.WriteLine("===============");
            int id = Helper.ReadInt("Enter id task: ");
            var result = await _dbTask.UpdateTaskByIdAsync(id);
            if (result == true)
            {
                Helper.PositiveResponse("Task changed successfully!");
            }
            else
            {
                Helper.NegativeResponse("Task not found, try again!");
            }
        }
        public async Task GetAllTasksAsync()
        {
            Console.Clear();
            Console.WriteLine("Get all task:");
            Console.WriteLine("===============");
            var tasks = await _dbTask.GetAllTasksAsync();
            foreach (var task in tasks)
            {
                Console.WriteLine($"Id: {task.Id} | Title: {task.Title}" +
                    $"\nDescription: {task.Description} | User: {task.User}" +
                    $"\nStart task: {task.StartTask} | Deadline: {task.Deadline}" +
                    $"\nStatus: {task.Status} |Priority: {task.Priority}");
            }
            Console.WriteLine();
            Console.WriteLine("Click to continue");
            Console.ReadKey();
        }
    }
}
