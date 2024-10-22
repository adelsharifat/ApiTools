using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBuilder.Helpers
{
    public static class ConsoleHelper
    {
        public static void Handle(Action action, Action startMessage = null, Action successMessage = null)
        {
            var dc = Console.ForegroundColor;
            try
            {
                if (startMessage is not null)
                    startMessage();

                action();

                if (successMessage is not null)
                    successMessage();
            }
            catch (Exception err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR:: {err.Message}");
            }finally
            {
                Console.ForegroundColor = dc;
            }
        }


        public static void WriteColorize(string text, ConsoleColor color)
        {
            var dc = Console.ForegroundColor;

            Console.ForegroundColor = color;

            Console.Write(text);

            Console.ForegroundColor = dc;
        }

        public static void WriteLineColorize(string text, ConsoleColor color)
        {
            var dc = Console.ForegroundColor;

            Console.ForegroundColor = color;

            Console.WriteLine(text);

            Console.ForegroundColor = dc;
        }

    }
}
