using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_LanchoneteSanduiches
{
    internal class MenuItem
    {
        Random random  = new Random();
        internal string[] Proteins = new string[] { "Roast beef", "Salami", "Turkey", "Ham", "Pastrami", "Tofu" };
        internal string[] Codiments = new string[] { "Yellow mustard", "Brown mustard", "Honey mustard", "Mayo", "Relish", "French dressing" };
        internal string[] Bread = new string[] { "Rye", "White", "Wheat", "Pumpernickel", "A roll" };
        internal string description = "";
        internal string price;

        internal void GenerateMenuItem()
        {
            string randomProtein = Proteins[random.Next(Proteins.Length)];
            string randomCodiments = Codiments[random.Next(Codiments.Length)];
            string randomBread = Bread[random.Next(Bread.Length)];

            description = randomProtein + " with " + randomCodiments + " with " + randomBread;
            decimal priceDecimal = random.Next(300, 801);
            price = (priceDecimal / 100.00M).ToString("c");

            Console.WriteLine("The price is " + price); //"c" informa ao ToString para formatar o valor com a moeda local
        }
    }
}
