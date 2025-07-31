using _17_TallGuy;

TallGuy tallGuy = new TallGuy() { height = 76, name = "Henrique" };
tallGuy.TalkAboutYourself();

Console.WriteLine($"The tall guy has {tallGuy.FunnyThingIHave}");
tallGuy.Honk();

class TallGuy : IClown
{
    public string name;
    public int height;

    public string FunnyThingIHave { get { return "big shoes"; } }

    public void Honk()
    {
        Console.WriteLine("Honk honk!");
    }

    public void TalkAboutYourself()
    {
        Console.WriteLine($"My name is {name} and I'm {height} inches tall.");
    }
}




