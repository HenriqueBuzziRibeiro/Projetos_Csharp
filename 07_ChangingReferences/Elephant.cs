using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ChangingReferences
{
    internal class Elephant
    {
        internal string name;
        internal int earSize;

        public Elephant(string name, int earSize)
        {
            this.name = name;
            this.earSize = earSize;
        }

        public void WhoAmI()
        {

            Console.WriteLine($"My name is {name}.");
            Console.WriteLine($"My ears are {earSize} inches tall.");
        }

        public void HearMessage(string message, Elephant whoSaidIt)
        {
            Console.WriteLine(name + " heard a message.");
            Console.WriteLine(whoSaidIt.name + " said this: " + message);
        }

        public void SpeakTo(string message, Elephant whoTalkTo)
        {
            whoTalkTo.HearMessage(message, this); //esse 'This' envia uma referência de si mesmo para outro Elephant
        }
    }
}