public class DndCharacter
{
    private static readonly Random rnd = new(DateTime.Now.Millisecond);

    public int Strength { get; }
    public int Dexterity { get; }
    public int Constitution { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }
    public int Hitpoints { get; }

    public DndCharacter(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
    {
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
        Wisdom = wisdom;
        Charisma = charisma;
        Hitpoints = 10+Modifier(constitution);
    }

    public static int Modifier(int score) => (int)Math.Floor((score - 10) / 2.0);

    public static int Ability() => new []{RollDie(6), RollDie(6), RollDie(6), RollDie(6)}.OrderBy(x => x).Skip(1).Sum();

    public static DndCharacter Generate() => new(Ability(), Ability(), Ability(), Ability(), Ability(), Ability());

    private static int RollDie(int sides) => rnd.Next(1, sides + 1);
}
