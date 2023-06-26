using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Meneger.Controllers.DataBase;
namespace Task_Meneger.Apps
{
    public class TestApp
    {
        public async void Start()
        {
            var test = new DataBaseMethodsForTask("Server=.; Database=MyDiary; Trusted_connection=True; Encrypt=Optional");
            var result = await test.GetAllTask();
            Console.WriteLine(result);
        }
      
    }
}
