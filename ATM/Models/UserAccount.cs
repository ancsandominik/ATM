using ATM.Models;
using System.Collections.Generic;

namespace ATM
{
    internal class UserAccount
    {
        internal string AccountNumber { get; set; }
        internal string PinNumber { get; set; }
        internal double Balance { get; set; }
        internal string FullName { get; set; }
        internal List<UserTransaction> Transactions { get; set; }

        internal UserAccount()
        {
            Transactions = new List<UserTransaction>();
        }
    }
}
