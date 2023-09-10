using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Console_App.Domain.Entities
{
    internal class UserAccount
    {
        int id;
        long cardNumber;
        int cardPin;
        long accountNumber;
        string name;
        decimal accountBalance;
        bool isLocked;
        int totalLogin;

        public int Id 
        {
            get { return id; }
            set { id = value; }
        }
        public long CardNumber 
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }
        public int CardPin
        {
            get { return cardPin; }
            set { cardPin = value; }
        }
        public long  AccountNumber 
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }
        public string Name 
        {
            get { return name; }
            set { name = value; }
        }
        public decimal AccountBalance 
        { 
            get { return accountBalance; }
            set { accountBalance = value; }
        }
        public bool IsLocked 
        { 
            get { return isLocked; }
            set { isLocked = value; }
        }
        public int TotalLogIn 
        { 
            get { return totalLogin; }
            set { totalLogin = value; }
        }

        public UserAccount(int id, long cardNumber, int cardPin, long accountNumber, string name, decimal accountBalance, bool isLocked, int totalLogin)
        {
            this.id = id;
            this.cardNumber = cardNumber;
            this.cardPin = cardPin;
            this.accountNumber = accountNumber;
            this.name = name;
            this.accountBalance = accountBalance;
            this.isLocked = isLocked;
            this.totalLogin = totalLogin;
        }
    }
}
