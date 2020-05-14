using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
  public  class Engine
    {
        private readonly AccountManager manager;

        public Engine()
        {
            this.manager = new AccountManager();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();

             

                try
                {
                    string res = "";

                    if (input[0] == "login")
                    {
                        

                        res = manager.Login(input[1], int.Parse(input[2]));
                    }
                    else if (input[0] == "logout")
                    {
                         manager.Logout();
                    }
                    else if (input[0] == "get")
                    {
                        res = manager.GetBalance();
                    }
                    else if (input[0] == "withdraw")
                    {
                        res = manager.Withdraw(int.Parse(input[1]));
                    }
                    else if (input[0] == "deposit")
                    {
                        res = manager.Deposti(int.Parse(input[1]));
                    }
                    else if (input[0] == "transfer")
                    {
                        res = manager.Transfer(int.Parse(input[1]), input[2]);
                    }
                    else if (input[0] == "history")
                    {
                        res = manager.History();
                    }

                    Console.WriteLine(res);
                }
                catch (Exception e )
                {

                    Console.WriteLine(e);
                    continue;
                }

            }
        }
    }
}
