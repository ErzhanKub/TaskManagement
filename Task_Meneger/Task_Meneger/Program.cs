using System.Text;
using Task_Meneger.Apps;
using Task_Meneger.Controllers.DataBase;

namespace AppProgram
{
    public class Program
    {
        public static  void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            TestApp app = new TestApp();
            app.Start();
        }
    }
}
