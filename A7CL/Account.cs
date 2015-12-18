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

            You cant use private fields in Contract.<function>...
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
            //Contract.Requires<ArgumentOutOfRangeException>(amount <= Balance);
            //Contract.Ensures(Contract.Result<double>() + amount == Balance); // Gives error since method dont have a return value
            Contract.EnsuresOnThrow<ArgumentException>(Contract.OldValue<double>(Balance) == Balance);
            if (Balance < amount)
                throw new ArgumentException("Not enough money"); // We should make our own exception for this


            Balance = Balance - amount;
        }

        [ContractInvariantMethod]
        private void ObjectInvariat()
        {
            Contract.Invariant(Balance > 0);
        }
        #endregion
    }
}
