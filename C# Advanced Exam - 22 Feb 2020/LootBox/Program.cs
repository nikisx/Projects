using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstBoxInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] secondBoxInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> firstBox = new Queue<int>(firstBoxInput);

            Stack<int> secondBox = new Stack<int>(secondBoxInput);

            var claimedItems = new List<int>();
            while (true)
            {
                if (firstBox.Count <= 0 || secondBox.Count<=0)
                {
                    break;
                }

                int currFirst = firstBox.Peek();
                int currSecond = secondBox.Peek();

                if ((currFirst+currSecond) % 2 == 0)                
                {
                    claimedItems.Add(currFirst + currSecond);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(currSecond);
                    secondBox.Pop();
                    
                }
            }

            if (firstBox.Count<=0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondBox.Count<=0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

           int loot= claimedItems.Sum();

            if (loot >=100)
            {
                Console.WriteLine($"Your loot was epic! Value: {loot}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {loot}");
            }
        }
    }
}
