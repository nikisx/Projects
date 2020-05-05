
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
            string pattern = @"U\$([A-z][a-z]+)U\$P@\$([A-Z]+|[a-z]+\d+)P@\$";


            int count = int.Parse(Console.ReadLine());
            int countSucc = 0;
            for (int i = 0; i < count; i++)
            {
                string reg = Console.ReadLine();

                Match match = Regex.Match(reg, pattern);

                if (match.Success)
                {
                    string username = match.Groups[1].Value;
                    string password = match.Groups[2].Value;
                    int countLetters = 0;
                    bool isValid = false;
                    for (int j = 0; j < password.Length; j++)
                    {
                        if (char.IsLetter(password[j]))
                        {
                            countLetters++;
                            if (countLetters >= 5)
                            {

                                isValid = true;
                                break;
                            }

                        }

                    }
                    if (username.Length >= 3 && isValid)
                    {
                        Console.WriteLine("Registration was successful");
                        Console.WriteLine($"Username: {username}, Password: {password}");
                        countSucc++;
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine($"Successful registrations: {countSucc}");
        }
    }
}
