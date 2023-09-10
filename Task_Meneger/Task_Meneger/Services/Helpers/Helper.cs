using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Meneger.Helpers
{
    public class Helper
    {
        public static string ReadString(string text)
        {
            Console.Write(text);
            var input = Console.ReadLine();
            if (input != null) return input;
            else throw new ArgumentNullException("Null string", nameof(input));

        }
        public static int ReadInt(string text)
        {
            Console.Write(text);
            return int.Parse(Console.ReadLine()); //TODO: Написать код для валидации. 
        }

        public static void PositiveResponse(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{text}");
            Console.ResetColor();
            Console.ReadKey(true);
        }

        public static void NegativeResponse(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{text}");
            Console.ResetColor();
            Console.ReadKey(true);
        }
    }
}
