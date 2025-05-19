using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_PickACardUI
{
    class CardPicker
    {
        static Random random = new Random();
        /// <summary>
        /// Escolha um número de cartas e retorneas aleatóriamente
        /// </summary>
        /// <param name="numberOfCards">The number of cards to pick.</param>
        /// <returns>An array of strings that contain the card names.</returns>
        public static string[] PickSomeCards(int numberOfCards)
        {
            string[] pickedCards = new string[numberOfCards];

            for (int i = 0; i < numberOfCards; i++)
            {
                pickedCards[i] = RandomValue() + " of " + RandomSuit();
            }

            return pickedCards;
        }

        private static string RandomSuit()
        {
            int value = random.Next(1,5);

            if (value == 1) return "Spades";
            if (value == 2) return "Hearts";
            if (value == 3) return "Clubs";
            return "Diamons";
        }

        private static string RandomValue()
        {
            int value = random.Next(1, 14);
            if (value == 1) return "Ace";
            if (value == 11) return "Jack";
            if (value == 12) return "Queen";
            if (value == 13) return "King";
            return value.ToString(); //Tem que retornar com 'ToString()' porque value é um 'int'
        }
    }
}
