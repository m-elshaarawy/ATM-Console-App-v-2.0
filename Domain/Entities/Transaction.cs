using ATM_Console_App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Console_App.Domain.Entities
{
    internal class Transaction
    {
        public int TransactionId { get; set; }
        public int UserAccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }

        public string Description { get; set; }

        public decimal TransactionAmount { get; set; }
    }
}
