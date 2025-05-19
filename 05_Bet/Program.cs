using _05_Bet;
using System.Runtime.CompilerServices;

Player bili = new Player() { name = "Bili", cash = 100};
Random random = new Random();
double odds = 0.75;

Console.WriteLine($"The odds are {odds}, do you want to bet? (Press 'S' if you want)");
string answer = Console.ReadLine();


while (answer == "S")
{
    bili.WriteInfo();
    Console.WriteLine("How much money do you want to bet?");

    string howmuch = Console.ReadLine();

    if (int.TryParse(howmuch, out int amount))
    {
        if (random.NextDouble() > odds)
        {
            Console.WriteLine("You won");
            bili.ReceiveCash(amount * 2);
        }
        else
        {
            Console.WriteLine("Bad luck, you lose.");
            bili.GiveCash(amount);
        }
    }

    Console.WriteLine("Do you want to keep betting?");
    answer = Console.ReadLine();
}

bili.WriteInfo();
