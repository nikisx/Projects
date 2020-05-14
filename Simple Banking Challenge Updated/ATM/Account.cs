using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    public class Account
    {
        private int balance;
        private string username;
        private List<string> history;
        public Account(string name, int pin)
        {
            this.Username = name;
            this.Balance = 0;
            this.history = new List<string>();
        }
        public string Username
        {
            get { return this.username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException("Username cannot be null or empty");
                }
                this.username = value;
            }
        }
        public int Balance
        {
            get { return this.balance; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.balance = value;
            }
        }

        public List<string> History => this.history;


       
    }
}
