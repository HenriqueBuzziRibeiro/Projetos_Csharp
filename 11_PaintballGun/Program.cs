
int numberOfBalls = PaintballGun.ReadInt(20, "Number of Balls");
int magazineSize = PaintballGun.ReadInt(16, "Magazine size");

Console.Write($"Loaded [false]: ");
bool.TryParse(Console.ReadLine(), out bool isLoaded);

PaintballGun gun = new PaintballGun(numberOfBalls, magazineSize, isLoaded);
while (true)
{
    Console.WriteLine($"{gun.TotalBalls} balls, {gun.GetBallsLoaded} balls loaded.");

    if (gun.IsEmpty())
    {
        Console.WriteLine("WARNING, you are out of ammo");
    }

    Console.WriteLine("Space to shoot, r to reload, + to add ammo and q to quit");
    char key = Console.ReadKey(true).KeyChar;

    if (key == ' ') Console.WriteLine($"Shooting returned {gun.Shoot()}");
    else if (key == 'r')
    {
        Console.WriteLine($"Gun is reloading");
        gun.Reload();
    }
    else if (key == '+')
    {
        Console.WriteLine("Adding balls.");
        gun.TotalBalls = gun.TotalBalls + gun.MagazineSize;
    }
    else if (key == 'q') return;
}

internal class PaintballGun
{
    public int MagazineSize { get; private set; } = 16;
    private int totalBalls;
    public int TotalBalls
    {
        get { return totalBalls; } //note que é usado o campo auxiliar 'totalBalls'
        set
        {
            if (value > 0) totalBalls = value;
            Reload();
        }
    }
    public int TotalLoadedBalls { get; private set; } //é possível privar o 'set', pode ser vizualizado de qualquer lugar mas modificado apenas dentro da classe

    public PaintballGun(int totalBalls, int magazineSize, bool loaded)
    {
        this.TotalBalls = totalBalls;
        MagazineSize = magazineSize;
        if (!loaded) Reload();
    }

    public int GetBallsLoaded() {  return TotalLoadedBalls; }
    public bool IsEmpty() {  return TotalLoadedBalls == 0; }
    public void Reload()
    {
        if(totalBalls > MagazineSize)
        {
            TotalLoadedBalls = MagazineSize;
        }
        else
        {
            TotalLoadedBalls = totalBalls;
        }
    }
    public bool Shoot()
    {
        if (TotalLoadedBalls == 0) return false;
        TotalLoadedBalls--;
        totalBalls--;
        return true;
    }
    public static int ReadInt(int lastUsedValue, string prompt)
    {
        Console.WriteLine($"{prompt} [{lastUsedValue}]");
        string line = Console.ReadLine();
        if (int.TryParse(line, out int value))
        {
            Console.WriteLine("value accepted (" + value + ")");
            return value;
        }
        else
        {
            Console.WriteLine("using default value (" + lastUsedValue + ")");
            return lastUsedValue;
        }
    }
}