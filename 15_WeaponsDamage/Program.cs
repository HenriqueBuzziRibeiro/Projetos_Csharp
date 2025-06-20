
using _15_WeaponsDamage;
using System.Runtime.CompilerServices;

SwordDamage swordDamage = new SwordDamage(RollDice(3));
ArrowDamage arrowDamage = new ArrowDamage(RollDice(1));

while (true)
{
    Console.WriteLine("0 for no magic/flaming, 1 for magic, 2 for flaming, 3 for both, anything else to quit");
    char key = Console.ReadKey().KeyChar;
    if (key != '0' && key != '1' && key != '2' && key != '3') return;

    Console.WriteLine("\nS for sword, A for arrow, anything else to quit: ");
    char weaponKey = Char.ToUpper(Console.ReadKey().KeyChar);

    switch (weaponKey)
    {
        case 'S':
            //swordDamage.Roll = RollDice(3);
            swordDamage.Magic = (key == '1' || key == '3');
            swordDamage.Flaming = (key == '2' || key == '3');
            Console.WriteLine($"Rolled {swordDamage.Roll} for {swordDamage.Damage}HP\n");
            break;

        case 'A':
            //arrowDamage.Roll = RollDice(1);
            arrowDamage.Magic = (key == '1' || key == '3');
            arrowDamage.Flaming = (key == '2' || key == '3');
            Console.WriteLine($"Rolled {arrowDamage.Roll} for {arrowDamage.Damage}HP\n");
            break;
        default:
            return;
    }
}

static int RollDice(int numberOfRolls)
{
    Random random = new Random();
    int total = 0;

    for (int i = 0; i < numberOfRolls; i++)
    {
        total = total + random.Next(1,7); 
    }

    return total;
}