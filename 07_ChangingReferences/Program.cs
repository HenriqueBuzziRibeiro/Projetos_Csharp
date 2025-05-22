using _07_ChangingReferences;

Elephant loyd = new Elephant("Loyd", 40);
Elephant lucinda = new Elephant("Lucinda", 33);

while (true)
{
    Console.WriteLine($"Press 1 for Loyd, 2 for Lucinda and 3 for swap");

    if (int.TryParse(Console.ReadLine(), out int value))
    {
        if (value == 1)
            loyd.WhoAmI();
        else if (value == 2)
            lucinda.WhoAmI();
        else if (value == 3)
        {
            Swap(ref loyd, ref lucinda);
        }
        else
            Console.WriteLine("Only is accept numbers 1, 2 or 3.");
    }
    else
    {
        Console.WriteLine("Only will be accepted numbers 1,2 or 3.");
    }

    Console.WriteLine("Press Q to quit, any other key to continue");
    char KeyChar = Console.ReadKey(true).KeyChar;
    if ((KeyChar == 'Q') || (KeyChar == 'q')) return;
}

static void Swap(ref Elephant elephant1, ref Elephant elephant2)
{
    Elephant saveReference = elephant1;
    elephant1 = elephant2;
    elephant2 = saveReference;
}


