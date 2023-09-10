using ATM_Console_App.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Console_App.UI
{
    internal static class Validator
    {
        internal static T Convert<T>(string prompt)
        {
            bool valid = false;
            string userInput;
            while (!valid)
            {
                userInput = Utility.GetUserInput(prompt);

                try
                {
                    var converter = TypeDescriptor.GetConverter(typeof(T));

                    if (converter != null)
                    {
                        return (T)converter.ConvertFromString(userInput);
                    }
                    else
                    {
                        return default;
                    }
                }
                catch
                {
                    Utility.WriteMessage("Invalid input ,try again :(",false);
                }
            }
            return default;
        }
        
    }
}
