using ATM_Console_App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Console_App.UI
{
    internal static class AppScreen
    {
        internal static void Welcome()
        {
            // clear console screen 
            Console.Clear();

            //set the title of console window
            Console.Title = "ATM_Console_App -V 2.0";

            // set the welcome message 
            Console.WriteLine("   ------------- Welcome to the upgraded version of ATM_Console_App -------------");

            //prompt the user to insert Card 
            Console.WriteLine("Please Insert your ATM Card :) ");
            Utility.PressEnterToContinue();

        }

        internal static UserAccount UserInputForm()
        {
            UserAccount tempAccount = new UserAccount(0, 0, 0, 0, "", 0, false, 0);

            tempAccount.CardNumber = Validator.Convert<long>("CardNumber");
            tempAccount.CardPin = Utility.GetPasswordInput("PinNumber");

            return tempAccount;
        }

        internal static void LoginProgress()
        {

            Console.WriteLine("\nChecking CardNumber and PIN . . .");

            Utility.PrintDotAnimation();
           
        }

        internal static void PrintLockScreen()
        {
            Console.Clear();
            Utility.WriteMessage("Your account is locked, Please call customer service for help :(",true);
            //Utility.PressEnterToContinue();
            Environment.Exit(0);
        }

        internal static void WelcomeUser(string Name)
        {
            Console.WriteLine($"\n--$ Welcome {Name} :)");
            Utility.PressEnterToContinue();
        }

        internal static void DisplayAppMenu()
        {
            Console.Clear();
            Console.WriteLine("\nPlease choose one of the following options ... ");
            Console.WriteLine(" 1- Deposit ");
            Console.WriteLine(" 2- Withdraw ");
            Console.WriteLine(" 3- Show balance ");
            Console.WriteLine(" 4- Exit ");

        }

        internal static void LogOutProgress() 
        {
            Utility.PrintDotAnimation();
            Utility.WriteMessage("\nThank you for using ATM Console App :)");

            Console.Clear();
        }
    }
}
