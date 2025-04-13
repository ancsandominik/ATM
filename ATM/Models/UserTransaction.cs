using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    internal class UserTransaction
    {
        internal string TransactionType { get; set; }
        internal DateTime TimeStamp { get; set; }
        internal double Amount { get; set; }

    }
}
