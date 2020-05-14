using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
   public class AccountManager
    {
       
        private AccountRepossitory accounts;
        private int index;
        public AccountManager()
        {
            this.accounts = new AccountRepossitory();
            index = this.accounts.Accounts.Count;
        }
        public string Login(string name, int pin)
        {
           var acc = new Account(name, pin);
            this.accounts.Add(acc);
            return $"Welcome, {acc.Username}";

        }

        public void Logout()
        {
            this.accounts.Remove();
            index--;
        }

        public string GetBalance()
        {
           
            if (index + 1 < accounts.Accounts.Count)
            {
                index++;
            }

            accounts.Accounts.ElementAt(index).History.Add("Got balance.");

            return accounts.Accounts.ElementAt(index).Balance.ToString();
        }

        public string Withdraw(int amount)
        {
           
            if (index + 1 < accounts.Accounts.Count)
            {
                index++;
            }

            if (amount > accounts.Accounts.ElementAt(index).Balance)
            {
                throw new InvalidOperationException("You cannot withdraw more money than ypu have in your balance");
            }
            accounts.Accounts.ElementAt(index).History.Add($"Withdrawn {amount}");

            accounts.Accounts.ElementAt(index).Balance -= amount;

            return "ok!";
        }
        public string Deposti(int amount)
        {
           
            if (index + 1 < accounts.Accounts.Count)
            {
                index++;
            }
            accounts.Accounts.ElementAt(index).History.Add($"Deposited {amount}");
            accounts.Accounts.ElementAt(index).Balance += amount;

            return "ok!";
        }
        public string Transfer(int amount, string username)
        {
            var accToTransfer = this.accounts.Accounts.FirstOrDefault(a => a.Username == username);

            if (!accounts.Accounts.Contains(accToTransfer))
            {
                throw new InvalidOperationException("There is not an account with that name!");
            }
            
            if (index + 1 < accounts.Accounts.Count)
            {
                index++;
            }

            if (amount > accounts.Accounts.ElementAt(index).Balance)
            {
                throw new InvalidOperationException("You cannot transfer more money than ypu have in your balance");
            }

            accounts.Accounts.ElementAt(index).History.Add($"Transfered {amount} to {username}");
            accounts.Accounts.ElementAt(index).Balance -= amount;
            accToTransfer.Balance += amount;
         
            return "ok!";
        }

        public string History()
        {
            if (index + 1 < accounts.Accounts.Count)
            {
                index++;
            }

            if (accounts.Accounts.ElementAt(index).History.Count <=0 )
            {
                throw new InvalidOperationException("History empty");
            }

            StringBuilder sb = new StringBuilder();


            foreach (var item in accounts.Accounts.ElementAt(index).History)
            {
                sb.AppendLine(item);
            }

            return sb.ToString();
        }
    }
}
