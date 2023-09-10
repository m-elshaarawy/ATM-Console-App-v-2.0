using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Console_App.Domain.Interfaces
{
    internal interface IUserAccountActions
    {
        void deposit();

        void withdraw();

        void ShowBalance();
    }
}
