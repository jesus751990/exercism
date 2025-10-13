public class Player
{
    public int RollDie() => new Random().Next(1, 19);

    public double GenerateSpellStrength() => Math.Round(new Random().NextDouble() * 100, 2);
}
