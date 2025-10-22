public enum Plant
{
    Violets, Radishes, Clover, Grass
}

public class KindergartenGarden
{
    public string[] Children => ["Alice", "Bob", "Charlie", "David", "Eve", "Fred", "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry"];
    private string[] lines;

    public KindergartenGarden(string diagram) => lines = diagram.Split('\n');

    public IEnumerable<Plant> Plants(string student)
    {
        var index = Array.IndexOf(Children, student) * 2;
        var plants = new Plant[4];
        plants[0] = CharToPlant(lines[0][index]);
        plants[1] = CharToPlant(lines[0][index + 1]);
        plants[2] = CharToPlant(lines[1][index]);
        plants[3] = CharToPlant(lines[1][index + 1]);
        return plants;
    }

    private static Plant CharToPlant(char v) => v switch { 'V' => Plant.Violets, 'R' => Plant.Radishes, 'C' => Plant.Clover, 'G' => Plant.Grass, _ => throw new NotImplementedException() };
}