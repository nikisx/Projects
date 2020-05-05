using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace IzpitPurva
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Complete")
                {
                    break;
                }

                string[] line = input.Split();

                string command = line[0];

                if (command == "Make")
                {
                    string action = line[1];
                    if (action == "Upper")
                    {
                        email = email.ToUpper();
                        Console.WriteLine(email);
                    }
                    else if (action == "Lower")
                    {
                        email = email.ToLower();
                        Console.WriteLine(email);
                    }
                }
                else if (command == "GetDomain")
                {
                    int count = int.Parse(line[1]);
                    StringBuilder sb = new StringBuilder();
                    for (int i = email.Length - 1; i >= 0; i--)
                    {
                        sb.Append(email[i]);
                    }
                    string domain = sb.ToString().Substring(0, count);
                    for (int i = domain.Length - 1; i >= 0; i--)
                    {
                        Console.Write(domain[i]);
                    }
                    Console.WriteLine();
                }
                else if (command == "GetUsername")
                {
                    if (email.Contains('@'))
                    {
                        int index = email.IndexOf('@');
                        string newEmail = email.Substring(0, index);
                        Console.WriteLine(newEmail);
                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                }
                else if (command == "Replace")
                {
                    char ch = char.Parse(line[1]);
                    string newEmail = email.Replace(ch, '-');
                    Console.WriteLine(newEmail);
                }
                else if (command == "Encrypt")
                {
                    for (int i = 0; i < email.Length; i++)
                    {
                        Console.Write($"{(int)email[i]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}


