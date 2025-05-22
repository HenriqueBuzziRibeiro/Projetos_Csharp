using _06_AbilityScoreCalculator;

AbilityScoreCalculator calculator = new AbilityScoreCalculator();

while (true)
{
    calculator.RollResult = ReadInt(calculator.RollResult, "Starting 4d6 roll");
    calculator.DivideBy = ReadDouble(calculator.DivideBy, "Divide by");
    calculator.AddAmount = ReadInt(calculator.AddAmount, "Add amount");
    calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");
    calculator.CalculateAbilityScore();
    Console.WriteLine("Calculated ability score: " + calculator.Score);
    Console.WriteLine("Press Q to quit, any other key to continue");
    char KeyChar = Console.ReadKey(true).KeyChar;
    if ((KeyChar == 'Q') || (KeyChar == 'q')) return;
}

static int ReadInt(int lastUsedValue, string prompt)
{
    Console.WriteLine($"{prompt} [{lastUsedValue}]");
    string line = Console.ReadLine();
    if(int.TryParse(line, out int value))
    {
        Console.WriteLine("value accepted (" + value + ")");
        return value;
    }
    else
    {
        Console.WriteLine("value accepted (" + value + ")");
        return lastUsedValue;
    }
}

static double ReadDouble(double lastUsedValue, string prompt)
{
    Console.WriteLine($"{prompt} [{lastUsedValue}]");
    string line = Console.ReadLine();
    if (double.TryParse(line, out double value))
    {
        Console.WriteLine("value accepted (" + value + ")");
        return value;
    }
    else
    {
        Console.WriteLine("value accepted (" + value + ")");
        return lastUsedValue;
    }
}