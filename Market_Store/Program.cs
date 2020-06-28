using System;

namespace Market_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            var bronzeCard = new BronzeCard(150, 0);
            Console.WriteLine(bronzeCard.GetDiscount());

            var silverCard = new SilverCard(850, 600);
            Console.WriteLine(silverCard.GetDiscount());

            var goldCard = new GoldCard(1300, 1500);
            Console.WriteLine(goldCard.GetDiscount());
        }
    }
}
