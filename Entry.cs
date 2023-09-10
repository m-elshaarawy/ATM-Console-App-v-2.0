using ATM_Console_App.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Console_App
{
    internal class Entry
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ATM_Console_App app = new ATM_Console_App();
                app.DataInit();
                app.Run();

                //Utility.PressEnterToContinue();

            }

        }
    }
}
