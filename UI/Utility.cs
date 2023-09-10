using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Console_App.UI
{
    internal static class Utility
    {

        private static int Tid;
        
        internal static int GetTransactionId()
        {
             return Tid+=1;
        }
        internal static string GetUserInput(string prompt)
        {
            Console.WriteLine($"Enter {prompt}");
            Console.Write("-> ");
            return Console.ReadLine();
        }

        internal static int GetPasswordInput(string prompt)
        {
            bool isPrompt = true;
            string asterics = "";
            int Pin = 0;
            StringBuilder input = new StringBuilder();
            while (true)
            {
                while (true)
                {
                    if (isPrompt)
                    {
                        Console.WriteLine($"Enter {prompt}");
                        Console.Write("-> ");
                    }
                    isPrompt = false;
                    ConsoleKeyInfo inKey = Console.ReadKey(true);

                    if (inKey.Key == ConsoleKey.Enter)
                    {
                        if (input.Length == 4)
                        {
                            break;
                        }
                        else
                        {
                            WriteMessage("\n\nPlease enter 4 digits Number\n", false);
                            isPrompt = true;
                            input.Clear();
                        }
                    }
                    else if (inKey.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input.Remove(input.Length - 1, 1);
                    }
                    else if (inKey.Key !=  ConsoleKey.Backspace)
                    {
                        input.Append(inKey.KeyChar);
                        Console.Write(asterics + "*");
                    }
                }

                try
                {
                    return (Pin = int.Parse(input.ToString()));
                }
                catch
                {
                    WriteMessage("\nPlease enter 4 digits Number x:(\n", false);
                    isPrompt = true;
                    input.Clear();
                }
            }
        }
        internal static void PrintDotAnimation(int timer = 10)
        {
            for (int i = 0; i < timer; i++)
            {
                Console.Write(" .");
                Thread.Sleep(200);
            }

            Console.Clear();
        }




        internal static void PressEnterToContinue()
        {
            Console.WriteLine("\nPress Enter To Continue ....... \n");
            Console.ReadKey();
        }



        internal static void WriteMessage(string msg, bool success = true)
        {
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine(msg); 
            Console.ResetColor();
            PressEnterToContinue();
        }
    }
}
