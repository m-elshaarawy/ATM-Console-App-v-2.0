using ATM_Console_App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Console_App.Domain.Interfaces
{
    internal interface ITransaction
    {
        void InsertTransAction(int Tid, TransactionType action, decimal Tamount, string Tdescription);
        void ViewTransaction();
    }
}
