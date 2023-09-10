using Newtonsoft.Json;
using Task_Meneger.Data.Models;
using Task_Meneger.Helpers;


namespace Task_Meneger.Controllers.Additional_settings
{
    public class JsonConnection //TODO: Реализовать.
    {
        public static void ExporJson(List<MyTask> tasks)
        {
            string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            var nameFile = Helper.ReadString("Enter file name: ");
            File.WriteAllText($"{nameFile}", json);
        }
        public static List<MyTask> ImportJson(string nameFile)
        {
            string json = File.ReadAllText($"{nameFile}");
            var tasksList = JsonConvert.DeserializeObject<List<MyTask>>(json);
            if(tasksList != null)
            {
                return tasksList;
            }
            Console.WriteLine("Empty file!");
            return new List<MyTask> { };
        }
    }
}
