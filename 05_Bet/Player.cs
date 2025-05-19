using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Bet
{
    internal class Player
    {
        internal string name;
        internal int cash;

        public void WriteInfo()
        {
            Console.WriteLine($"{name} has {cash} in the wallet yet.");
        }

        public int GiveCash(int amount)
        {
            if (cash < amount)
                Console.WriteLine($"The amount is {cash} and it isn't enoght.");
            else
                cash = cash - amount;
            return cash;
        }

        public int ReceiveCash(int amount)
        {
            cash = cash + amount;
            return cash;
        }
    }
}