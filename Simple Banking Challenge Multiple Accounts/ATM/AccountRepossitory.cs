using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
  public  class AccountRepossitory
    {
        private List<Account> accounts;
        private int index;
        public AccountRepossitory()
        {
            this.accounts = new List<Account>();
            index = 0;
        }

        public IReadOnlyCollection<Account> Accounts => this.accounts.AsReadOnly();

        public void Add(Account account)
        {
            this.accounts.Add(account);
            index++;
        }

        public void Remove()
        {
            //Might have a problem whit the indexes
            

            
            if (index  <= accounts.Count)
            {
                index--;
            }

            this.accounts.RemoveAt(index);
        }
    }
}
