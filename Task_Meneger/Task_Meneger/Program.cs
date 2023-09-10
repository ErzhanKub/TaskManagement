using Microsoft.Extensions.DependencyInjection;
using Task_Meneger.Apps;
using Task_Meneger.Controllers.DataBase;
using Task_Meneger.Data.EFBase;
using Task_Meneger.Interface;
using Task_Meneger.Services.TaskManagers;
using Task_Meneger.Services.UserManagers;

//TODO: Закончить проект - проверка на паттерны SOLID - Расширить функциональность.

var services = new ServiceCollection();
services.AddDbContext<AppDbContext>();
services.AddSingleton<ReleaseApp>();
services.AddScoped<DbMethodsForTasks>();
services.AddScoped<DbMethodsForUsers>();
services.AddScoped<ITaskMenegement, TaskManagement>();
services.AddScoped<IUserManagement, UserManagement>();
var serviceProvider = services.BuildServiceProvider();


var releaseApp = serviceProvider.GetService<ReleaseApp>();
await releaseApp.Start();
