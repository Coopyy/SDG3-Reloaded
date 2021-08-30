using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SDG3R.Core.Logging
{
    public class IConsole
    {
        private static void HandleCommand(string input)
        {
            string Send = "command not found";
            string[] breaks = input.Split(' ');

            foreach (string str in breaks)
                switch (str)
                {
                    case "exit":
                        Process.GetCurrentProcess().Close();
                        break;

                    default: break;
                }
            Console.WriteLine(Send);
        }

        static Thread ConsoleThread = new Thread(ExConsole);
        static ConsoleInputOutput s = new ConsoleInputOutput();
        static CommandWindow w = new CommandWindow();
        static CommandInputHandler x = new CommandInputHandler(HandleCommand);

        public static void SetTitle(string title)
        {
            w.title = title;
        }

        public static void Setup(string title = "SDG3 Reloaded")
        {
            w.title = title;
            s.initialize(w);
            s.inputCommitted += x;

            ConsoleThread.Start();
        }

        private static void ExConsole()
        {
            while (true)
                s.update();
        }

        public static void SendConsole(string content, ConsoleColor color)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[SDG3R] ");
            Console.ForegroundColor = color;
            Console.WriteLine(content);
            Console.ResetColor();
        }
        public static void SendConsole(string content, ConsoleColor color = ConsoleColor.White, ConsoleColor bgcolor = ConsoleColor.Black)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[SDG3R] ");
            Console.BackgroundColor = bgcolor;
            Console.ForegroundColor = color;
            Console.WriteLine(content);
            Console.ResetColor();
        }
    }
}
