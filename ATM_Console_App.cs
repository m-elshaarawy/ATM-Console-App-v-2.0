using ATM_Console_App.Domain.Entities;
using ATM_Console_App.Domain.Enums;
using ATM_Console_App.Domain.Interfaces;
using ATM_Console_App.UI;

namespace ATM_Console_App
{
    class ATM_Console_App : IUserLogin , IUserAccountActions , ITransaction
    {
        private List<UserAccount> accounts;
        public UserAccount selectedAccount;
        private List<Transaction> transactions;

        public void DataInit()
        {
            accounts = new List<UserAccount>
            {   /*int id, long cardNumber, int cardPin, long accountNumber, string name, decimal accountBalance, bool isLocked, int totalLogin*/
                new UserAccount(1 ,12341234, 1234, 123456,"m_elshaarawy" ,1000000 ,false ,0),
                new UserAccount(2 ,22223333, 1234, 656986,"alex hoka"    ,50.50m  ,true ,0),
                new UserAccount(3 ,12341234, 1234, 897451,"soso hoka"    ,100.50m ,false ,0),
            };

            transactions = new List<Transaction>();
        }
        /*----------------------------------------------------------------------------------*/
        public void Run()
        {
            AppScreen.Welcome();
            CheckUserLogData();
            AppScreen.WelcomeUser(selectedAccount.Name);
            AppScreen.DisplayAppMenu();
            ProcessMenuOption();

        }

        /*----------------------------------------------------------------------------------*/
        public void CheckUserLogData()
        {
            bool valid = false;
            bool inValid = false;
            int cheker = 0;

            while (valid == false)
            {
                inValid = false;
                UserAccount inAccount = AppScreen.UserInputForm();
                AppScreen.LoginProgress();
                foreach (UserAccount account in accounts)
                {
                    selectedAccount = account;
                    if (inAccount.CardNumber.Equals(selectedAccount.CardNumber))
                    {
                        inValid = true;
                        selectedAccount.TotalLogIn += 1;

                        if (inAccount.CardPin.Equals(selectedAccount.CardPin))
                        {
                            selectedAccount = account;

                            if (selectedAccount.IsLocked || selectedAccount.TotalLogIn > 3)
                            {
                                AppScreen.PrintLockScreen();
                            }
                            else
                            {
                                selectedAccount.TotalLogIn = 0;
                                valid = true;
                                cheker = 0;
                                break;
                            }
                        }

                            Utility.WriteMessage("\nInvalid Card number or PIN -:(", false);
                            if (selectedAccount.TotalLogIn == 3)
                            {
                                selectedAccount.IsLocked = true;
                                AppScreen.PrintLockScreen();
                            }
                        
                    }
                }
                if (inValid == false)
                {
                    cheker++;
                    Utility.WriteMessage("\nInvalid Card number or PIN :(", false);
                        if (cheker == 3)
                        {
                            Utility.WriteMessage(" you have exceeded the allowed login attempts :(", false);
                            Environment.Exit(0);
                        }
                    }
                Console.Clear();
            }
            
        }

        /*----------------------------------------------------------------------------------*/
        public void ProcessMenuOption()
        {
            bool valid = false;

            while (!valid)
            {
                switch (Validator.Convert<int>("an option :"))
                {
                    case (int)AppMenu.Deposit:
                        deposit();
                        valid = true;
                        break;
                    case (int)AppMenu.Withdraw:
                        withdraw();
                        valid = true;
                        break;
                    case (int)AppMenu.Show_Balance:
                        Console.WriteLine(" Checking Balance ...");
                        Utility.PrintDotAnimation();
                        ShowBalance();
                        valid = true;
                        break;
                    case (int)AppMenu.Exit:
                        Console.WriteLine(" Exiting ...");
                        AppScreen.LogOutProgress();
                        valid = true;
                        break;
                    default:
                        Console.WriteLine(" Default action ...");
                        break;
                }
            }

        }

        public void deposit()
        {

            decimal deposit = Validator.Convert<decimal>("deposit amount");
            Console.WriteLine(" Depositing ...");
            Utility.PrintDotAnimation();
            // add transaction to transactions list 
            InsertTransAction(selectedAccount.Id, TransactionType.Deposit, deposit, "N/A");
            // update balance
            selectedAccount.AccountBalance += deposit;
            Utility.WriteMessage("\nthank you for your $$ your new balance is :" + selectedAccount.AccountBalance + " $");

        }

        public void withdraw()
        {
           
            decimal withdraw = Validator.Convert<decimal>("withdraw amount");
            if (withdraw > selectedAccount.AccountBalance)
            {
                Utility.WriteMessage("\nInsufficient balance :(",false);
            }
            else
            {
                Console.WriteLine(" Withdrawing ...");
                Utility.PrintDotAnimation();
                // add transaction to transactions list 
                InsertTransAction(selectedAccount.Id, TransactionType.Withdraw, withdraw, "N/A");
                // update balance
                selectedAccount.AccountBalance -= withdraw;
                Utility.WriteMessage("thank you :)  your new balance is :" + selectedAccount.AccountBalance + " $");
            }
        }

        public void ShowBalance()
        {
            Utility.WriteMessage($"\n Your account Balance is : {selectedAccount.AccountBalance} $");
        }

        /*--------------------------------- Transaction -----------------------------------------*/

        public void InsertTransAction(int Userid, TransactionType action, decimal Tamount, string Tdescription)
        {

            var transaction = new Transaction()
            {
                TransactionId = Utility.GetTransactionId(),
                UserAccountId = Userid,
                TransactionType = action,
                TransactionAmount = Tamount,
                Description = Tdescription,
                TransactionDate = DateTime.Now,
            };

            transactions.Add(transaction);

        }

        public void ViewTransaction()
        {
            throw new NotImplementedException();
        }
    }
}