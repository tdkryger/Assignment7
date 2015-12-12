using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A7CL
{
    public class Account
    {
        /* Ran into this bug or feature or whatever MS calls it:
            Code Contracts CC1038 BUG

            https://social.msdn.microsoft.com/Forums/en-US/b89bd560-340a-4ab3-8ec9-c80e3120bf1f/code-contracts-cc1038-bug?forum=codecontracts

            You cant use private fields as base for a property like this:

            private double _balance=0;
            public double Balance{get{return _balance;}}
        */

        #region Properties
        public double Balance { get; private set; }
        #endregion

        #region Public methods
        public void Deposit(double amount)
        {
            Contract.Requires<ArgumentOutOfRangeException>(amount > 0);
            Balance = Balance + amount;
        }

        public void Withdraw(double amount)
        {
            Contract.Requires<ArgumentOutOfRangeException>(amount > 0);
            Contract.Requires<ArgumentOutOfRangeException>(amount <= Balance);
            Balance = Balance - amount;
        }
        #endregion
    }
}
