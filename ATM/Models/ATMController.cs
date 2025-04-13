using System;
using ATM.Models;

namespace ATM
{
    internal class ATMController
    {
        private UserAccount _activeAccount = null;

        internal ATMController()
        {
            _activeAccount = new UserAccount
            {
                AccountNumber = "1234",
                PinNumber = "9999",
                Balance = 161.23
            };
        }

        public void DisplayLoginScreen()
        {
            string accountNumberPrompt = "Enter account number";
            string pinNumberPrompt = "Enter PIN number";

            Console.WriteLine(accountNumberPrompt);
            string accountNumber = Console.ReadLine();
            Console.WriteLine(pinNumberPrompt);
            string pinNumber = Console.ReadLine();

            if (accountNumber == _activeAccount.AccountNumber && pinNumber == _activeAccount.PinNumber)
            {
                DisplayMainMenuScreen();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Authentication failed");
                DisplayLoginScreen();
            }
            Console.ReadKey();
        }

        private void DisplayMainMenuScreen()
        {
            Console.Clear();
            Console.WriteLine();

            Console.WriteLine("[ 1 ] Check Account Balance");
            Console.WriteLine("[ 2 ] Deposit");
            Console.WriteLine("[ 3 ] Withdrawn");
            Console.WriteLine("[ 4 ] Recent Tranactions");
            Console.WriteLine("[ 5 ] Logout");

            Console.WriteLine();
            Console.WriteLine("Select an option and press 'Enter' key");

            string selectedOption = Console.ReadLine();

            switch (selectedOption)
            {
                case "1":
                    DisplayAccountBalanceScreen();
                    break;
                case "2":
                    DisplayDepositScreen();
                    break;
                case "3":
                    DisplayWithdrawnScreen();
                    break;
                case "4":
                    DisplayRecentTransactionScreen();
                    break;
                case "5":
                    Logout();
                    break;
                default:
                    Console.WriteLine("Invalid selection. Press any key to continue.");
                    Console.ReadKey();
                    break;
            }
        }

        private void DisplayAccountBalanceScreen()
        {
            Console.Clear();
            Console.WriteLine("Account Ballance");

            Console.WriteLine();
            Console.WriteLine($"Current account balance: ${_activeAccount.Balance}");

            Console.ReadKey();
            DisplayMainMenuScreen();
        }

        private void DisplayDepositScreen()
        {
            Console.Clear();
            Console.WriteLine("Deposit");

            Console.WriteLine();
            Console.WriteLine("Enter deposit amount and press 'Enter'");

            string depositAmount = Console.ReadLine();
            double amount;

            if (double.TryParse(depositAmount, out amount))
            {
                _activeAccount.Balance = _activeAccount.Balance + amount;
                Console.WriteLine();
                Console.WriteLine($"Deposit amount ${amount} accepted. Press any key to continue.");
                
                _activeAccount.Transactions.Add(new UserTransaction
                {
                    Amount = amount,
                    TimeStamp = DateTime.Now,
                    TransactionType = "Deposit"
                });

                Console.ReadKey();
                DisplayMainMenuScreen();
            }

            Console.ReadKey();
            DisplayMainMenuScreen();
        }

        private void DisplayWithdrawnScreen()
        {
            Console.Clear();
            Console.WriteLine("Withdraw");

            Console.WriteLine();
            Console.WriteLine("Enter withdraw amount and press 'Enter'");

            string _withdrawAmount = Console.ReadLine();
            double amount;

            if (double.TryParse(_withdrawAmount, out amount))
            {
                if (amount <= _activeAccount.Balance)
                {
                    _activeAccount.Balance = _activeAccount.Balance - amount;
                    Console.WriteLine();
                    Console.WriteLine($"Withdraw amount ${amount} accepted. Press any key to continue.");

                    _activeAccount.Transactions.Add(new UserTransaction
                    {
                        Amount = amount,
                        TimeStamp = DateTime.Now,
                        TransactionType = "Withdraw"
                    });

                    Console.ReadKey();
                    DisplayMainMenuScreen();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Amount exceeds account balance. Press any key to continue.");
                    Console.ReadKey();
                    DisplayMainMenuScreen();
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid amount specified. Press any key to continue.");
                Console.ReadKey();
                DisplayWithdrawnScreen();
            }

            Console.ReadKey();
            DisplayMainMenuScreen();
        }

        private void DisplayRecentTransactionScreen()
        {
            Console.Clear();
            Console.WriteLine("Recent Transactions");

            Console.WriteLine();
            foreach (UserTransaction transaction in _activeAccount.Transactions)
            {
                Console.WriteLine($"Date: {transaction.TimeStamp.ToShortDateString()} | Amount: ${transaction.Amount} | TransactionType: {transaction.TransactionType}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");

            Console.ReadKey();
            DisplayMainMenuScreen();
        }

        private void Logout()
        {
            Console.Clear();
            DisplayLoginScreen();
        }
    }
}
