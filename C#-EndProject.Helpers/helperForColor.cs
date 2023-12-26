using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__EndProject.Helpers
{
    public class helperForColor
    {
        public static void changeTextColor(ConsoleColor consoleColor, string word)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(word);
            Console.ResetColor();
        }
    }
}
