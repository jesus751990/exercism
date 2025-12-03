using System.Text;

public static class Tournament
{
    private static readonly string _header = "Team                           | MP |  W |  D |  L |  P";
    private static Dictionary<string, Team> _teams = [];
    public static void Tally(Stream inStream, Stream outStream)
    {
        _teams.Clear();
        var reader = new StreamReader(inStream);
        var text = reader.ReadToEnd();
        GetTeams(text);
        var sortedTeams = _teams.Values
            .OrderByDescending(t => t.Points)
            .ThenBy(t => t.Name)
            .ToList();

        var headerBytes = Encoding.UTF8.GetBytes(_header);
        outStream.Write(headerBytes, 0, headerBytes.Length);
        foreach (var team in sortedTeams)
        {
            var row = GetRow(team);
            var bytes = Encoding.UTF8.GetBytes(row);
            outStream.Write(bytes, 0, bytes.Length);
        }
    }

    private static void GetTeams(string input)
    {
        var rows = input.Split('\n').Where(s => !string.IsNullOrEmpty(s));
        foreach (var row in rows)
        {
            var teamValues = row.Split(';');
            var team1 = teamValues[0];
            var team2 = teamValues[1];
            var result = teamValues[2];
            switch (result)
            {
                case "win":
                    GetOrCreateTeam(team1).Win();
                    GetOrCreateTeam(team2).Lose();
                    break;
                case "loss":
                    GetOrCreateTeam(team1).Lose();
                    GetOrCreateTeam(team2).Win();
                    break;
                case "draw":
                    GetOrCreateTeam(team1).Draw();
                    GetOrCreateTeam(team2).Draw();
                    break;
            }
        }
    }

    private static Team GetOrCreateTeam(string name)
    {
        if (!_teams.TryGetValue(name, out var team))
        {
            team = new Team(name);
            _teams.Add(name, team);
        }
        return team;
    }

    private static string GetRow(Team team) => $"\n{team.Name,-30} | {team.Played,2} | {team.Won,2} | {team.Drawn,2} | {team.Lost,2} | {team.Points,2}";
}

public class Team
{
    public Team(string name) => Name = name;

    public string Name { get; set; }
    public int Won { get; set; }
    public int Lost { get; set; }
    public int Drawn { get; set; }
    public int Played => Won + Lost + Drawn;
    public int Points => 3 * Won + Drawn;

    public void Win() => Won++;
    public void Lose() => Lost++;
    public void Draw() => Drawn++;
}
