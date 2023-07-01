using Microsoft.Extensions.Configuration;
using System.Text;
using Task_Meneger.Apps;
using Task_Meneger.Controllers.Additional_settings.Connection;
using Task_Meneger.Controllers.DataBase;
using Task_Meneger.Controllers.TaskManager;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

var con = new Connection();
//ReleaseApp app = new ReleaseApp(con.Start());
//await app.Start();
var task = new TaskManager(1,con.Start());
task.AddNewTask();

