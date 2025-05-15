using _03_PickRandomCards;

Console.WriteLine("Enter the number of cards to pick: ");

string line = Console.ReadLine();

if(int.TryParse(line, out int numberOfCards))
{
    string[] deck = CardPicker.PickSomeCards(numberOfCards);
    foreach(string cards in deck)
    {
        Console.WriteLine(cards);
    }
}
else
{
    Console.WriteLine("Just numbers are valid");
}

