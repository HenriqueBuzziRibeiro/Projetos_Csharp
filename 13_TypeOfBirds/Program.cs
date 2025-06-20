using System.Reflection;
using System.Xml;

while (true)
{
    Bird bird;
    Console.WriteLine("\nPress P for pigeon, O for Ostrich: ");
    char Key = Char.ToUpper(Console.ReadKey().KeyChar);
    if (Key == 'P')
    {
        bird = new Pigeon();
    }
    else if (Key == 'O')
    {
        bird = new Ostrich();
    }
    else return;
    Console.WriteLine("\nHow many eggs should it lay? ");
    if (!int.TryParse(Console.ReadLine(), out int numberOfEggs)) return;
    Egg[] eggs = bird.LayEggs(numberOfEggs);
    foreach(Egg egg in eggs)
    {
        Console.WriteLine(egg.Description);
    }
}

class Egg
{
    public double Size { get; private set; }
    public string Color { get; private set; }


    public Egg(double size, string color)
    {
        Size = size;
        Color = color;
    }

    public virtual void Description()
    {
        Console.WriteLine($"A egg with {Size}cm and color {Color}");
    }
}

class BrokenEgg : Egg
{
    public BrokenEgg(string color) : base(0, color)
    {
    }

    public override void Description()
    {
        Console.WriteLine($"A Pigeon laid a broken egg.");
    }
}

class Bird
{
    public static Random Randomizer = new Random();
    public virtual Egg[] LayEggs(int numberOfEggs)
    {
        Console.Error.WriteLine("Bird.LayEggs should never get called, only it's sons can call");
        return new Egg[0];
    }
}

class Pigeon : Bird
{
    public override Egg[] LayEggs(int numberOfEggs)
    {
        Egg[] listEggs = new Egg[numberOfEggs];
        for (int i = 0; i<numberOfEggs; i++)
        {
            if(Randomizer.Next(4) == 0)
            {
                listEggs[i] = new BrokenEgg("White");
            }
            else 
            {
                Egg egg = new(Randomizer.NextDouble() * 2 + 1, "White");
                listEggs[i] = egg;
            }          
        }

        return listEggs;
    }
}

class Ostrich : Bird
{
    public override Egg[] LayEggs(int numberOfEggs)
    {
        Egg[] listEggs = new Egg[numberOfEggs];
        for (int i = 0; i < numberOfEggs; i++)
        {
            Egg egg = new(Randomizer.NextDouble() + 12, "Speckled");
            listEggs[i] = egg;
        }

        return listEggs;
    }
}