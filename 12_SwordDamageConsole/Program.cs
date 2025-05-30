using _12_SwordDamageConsole;
using System.Runtime.CompilerServices;

SwordDamage swordDamage = new SwordDamage(RollDice());

while(true)
{
    Console.WriteLine("0 for no magic/flaming, 1 for magic, 2 for flaming, 3 for both, anything else to quit");
    char key = Console.ReadKey().KeyChar;

    if (key != '0' && key != '1' && key != '2' && key != '3') return;
    swordDamage.Roll = RollDice();
    if (key == 1 || key == 3) swordDamage.Magic = true;
    swordDamage.FlamingDamage = (key == 2 || key == 3);
    Console.WriteLine($"Rolled {swordDamage.Roll} for {swordDamage.Damage}HP");
}

static int RollDice()
{
    Random random = new Random();
    return random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
}