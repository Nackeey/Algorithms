using System;
using System.Collections.Generic;
using System.Linq;

namespace Fractional_Knapsack_Problem
{
    class Item
    {
        public double Weight { get; set; }

        public double Price { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var capacity = double.Parse(Console.ReadLine()
                .Split(' ')
                [1]);

            var items = double.Parse(Console.ReadLine()
                .Split()
                [1]);

            var allItems = new List<Item>();

            for (int i = 0; i < items; i++)
            {
                var currentItem = Console.ReadLine().Split(' ');

                allItems.Add(new Item
                {
                    Weight = double.Parse(currentItem[2]),
                    Price = double.Parse(currentItem[0])
                });
            }

            allItems = allItems
                .OrderByDescending(i => i.Price / i.Weight)
                .ToList();

            var index = 0;
            var totalPrice = 0.0;

            while (capacity > 0 && index < allItems.Count)
            {
                var currentItem = allItems[index];
                var takenQuantity = Math.Min(capacity, currentItem.Weight);

                var percentage = takenQuantity / currentItem.Weight;

                totalPrice += percentage * currentItem.Price;

                capacity -= takenQuantity;

                index++;

                var percAsString = percentage == 100 ? "100" : $"{percentage * 100:f2}";

                Console.WriteLine($"Take {percAsString}% of them with price {currentItem.Price:f2} and weight {currentItem.Weight:f2}");
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
