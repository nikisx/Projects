using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Treta
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Statistics")
                {
                    break;
                }

                string[] line = input.Split("->");

                string command = line[0];

                if (command == "Add")
                {
                    string username = line[1];
                    if (!people.ContainsKey(username))
                    {
                        var email = new List<string>();
                        people.Add(username, email);
                    }
                    else
                    {
                        Console.WriteLine($"{username} is already registered");
                    }

                }
                else if (command == "Send")
                {
                    string username = line[1];
                    string email = line[2];

                    if (people.ContainsKey(username))
                    {
                        people[username].Add(email);
                    }
                }
                else if (command == "Delete")
                {
                    string username = line[1];

                    if (people.ContainsKey(username))
                    {
                        people.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                }
            }

            Console.WriteLine($"Users count: {people.Count}");

            foreach (var item in people.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                var emails = item.Value;
                foreach (var email in emails)
                {
                    Console.WriteLine($"- {email}");
                }
            }
        }
    }
}