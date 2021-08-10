using FavoritePizzaToppings.Pizzas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FavoritePizzaToppings
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.ReadAllText(@"C:\Users\Jesse\Downloads\pizzas.json");
            var pizzas = JsonConvert.DeserializeObject<List<Pizza>>(file);
            var toppingsList = pizzas.GroupBy(pizza => String.Join(',', pizza.Toppings.OrderBy(x => x)));
            var toppingCountList = new List<(string toppingName, int count)>();
            foreach (var toppingCombo in toppingsList)
            {
                string name = toppingCombo.Key;
                int count = toppingCombo.ToList().Count;
                toppingCountList.Add((name, count));
            }
            var toppingCountListOrdered = toppingCountList.OrderByDescending(x => x.count).Take(20).ToList();
            var place = 1;
            // Printer function
            foreach (var topping in toppingCountListOrdered)
            {
                Console.WriteLine($"{(place == 1 ? "1st" : place == 2 ? "2nd" : place == 3 ? "3rd" : place + "th")} - {topping.toppingName}: has been ordered {topping.count} times");
                place++;
            }
        }
    }
}
