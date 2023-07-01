using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Meneger.Controllers.Additional_settings.MenuOption;

namespace Task_Meneger.Views
{
    public class ConsoleView
    {
        public static void StartMainMenu()
        {
            var menuOptions = new List<Option>()
            {
            new Option() { Title = "Список продуктов", IsSelected = true, OnSelect = StartProductMenu },
            new Option() { Title = "Поставщики", IsSelected = false },
            new Option() { Title = "Телефонная книга", IsSelected = false }
            };

            var menu = new Menu(menuOptions);

            NavigateMenu(menu);
        }

        public static void StartProductMenu()
        {
            var menuOptions = new List<Option>()
            {
            new Option() { Title = "Посмотреть продукты", IsSelected = true },
            new Option() { Title = "Добавить продукт", IsSelected = false }
        };

            var menu = new Menu(menuOptions);

            NavigateMenu(menu);
        }

        private static void NavigateMenu(Menu menu)
        {
            var next = true;

            do
            {
                menu.Render();

                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.Escape:
                        next = false;
                        break;
                    case ConsoleKey.UpArrow:
                        menu.MoveOption(-1);
                        break;
                    case ConsoleKey.DownArrow:
                        menu.MoveOption(1);
                        break;
                    case ConsoleKey.Enter:
                        menu.ActivateOption();
                        break;
                    default:
                        break;
                }

            } while (next);
        }
    }
}
