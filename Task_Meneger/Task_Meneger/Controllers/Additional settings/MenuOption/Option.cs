using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Meneger.Controllers.Additional_settings.MenuOption
{
    public class Option
    {
        public bool IsSelected { get; set; }
        public string Title { get; set; } = string.Empty;
        public Action OnSelect { get; set; } = () => { };
    }
}
