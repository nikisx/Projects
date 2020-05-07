using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
   public class AccountManager
    {
        private Account acc;
        

        public AccountManager()
        {
            
        }
        public string Login(string name, int pin)
        {
             acc = new Account(name, pin);
            
            return $"Welcome, {acc.Username}";

        }

        public void Logout()
        {
            Environment.Exit(0);
        }

        public string GetBalance()
        {
           

            return acc.Balance.ToString();
        }

        public string Withdraw(int amount)
        {
            if (amount > acc.Balance)
            {
                throw new InvalidOperationException("You cannot withdraw more money than ypu have in your balance");
            }

            acc.Balance -= amount;

            return "ok!";
        }
        public string Deposti(int amount)
        {
          

            acc.Balance += amount;

            return "ok!";
        }
        public string Transfer(int amount, string username)
        {
            if (amount > acc.Balance)
            {
                throw new InvalidOperationException("You cannot transfer more money than ypu have in your balance");
            }

            acc.Balance -= amount;

         
            return "ok!";
        }
    }
}
