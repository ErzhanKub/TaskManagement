using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Meneger.Controllers.Additional_settings.Connection
{
    public class Connection
    {
        public string Start()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = config.GetSection("ConnectionStrings:DefaultConnection").Value;
            return connectionString;
        }
    }
}
