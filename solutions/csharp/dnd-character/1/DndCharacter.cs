public class DndCharacter(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int hitpoints)
{
    public int Strength { get; } = strength;
    public int Dexterity { get; } = dexterity;
    public int Constitution { get; } = constitution;
    public int Intelligence { get; } = intelligence;
    public int Wisdom { get; } = wisdom;
    public int Charisma { get; } = charisma;
    public int Hitpoints { get; } = hitpoints;

    public static int Modifier(int score) => (int)Math.Floor((score - 10) / 2.0);

    public static int Ability()
    {
        var rolls = new List<int>();
        var random = new Random();
        for (int i = 0; i < 4; i++)
        {
            rolls.Add(random.Next(1, 7));
        }
        rolls.Remove(rolls.Min());
        return rolls.Sum();
    }

    public static DndCharacter Generate()
    {
        var constitution = Ability();
        return new DndCharacter(Ability(), Ability(), constitution, Ability(), Ability(), Ability(), 10 + Modifier(constitution));
    } 
}
