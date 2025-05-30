
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Welmcome to Hilo.");
Console.WriteLine($"Guess numbers between 1 and {HiloGame.MAXIMUM}.");
HiloGame.Hint();
while(HiloGame.GetPot() > 0)
{
    Console.WriteLine("Press h for higher, 1 for lower, ? to buy a hint.");
    Console.WriteLine($" or any other key to quit with {HiloGame.GetPot()}.");
    char key = Console.ReadKey(true).KeyChar;
    if (key == 'h') HiloGame.Guess(true);
    else if (key == '1') HiloGame.Guess(false);
    else if (key == '?') HiloGame.Hint();
    else return;

}

Console.WriteLine("The pot is empty. Bye!");

static class HiloGame
{

    static public int MAXIMUM = 10;
    static private Random random = new Random();
    static private int currentNumber = random.Next(1, MAXIMUM + 1);
    static private int pot = 10;

    static public void Guess(bool higher) 
    {
        int nextNumber = random.Next(1, MAXIMUM + 1);
        if (higher && nextNumber>currentNumber || !higher && nextNumber < currentNumber)
        {
            Console.WriteLine("You guessed right.");
            pot = pot + 1;
        }
        else
        {
            Console.WriteLine("You guessed wrong");
            pot = pot - 1;
        }

        currentNumber = nextNumber;
        Console.WriteLine($"The current number is {currentNumber}");
    }

    static public void Hint()
    {
        if(currentNumber>=MAXIMUM/2)
            Console.WriteLine($"The number is at least {MAXIMUM / 2}");
        else
            Console.WriteLine($"The number is at most {MAXIMUM / 2}");
        pot = pot - 1;
    }

    static public int GetPot() { return pot; }



}