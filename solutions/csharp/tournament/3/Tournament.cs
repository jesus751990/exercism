public static class Tournament
{
    public static void Tally(Stream inStream, Stream outStream)
    {
        using var reader = new StreamReader(inStream);
        var text = reader.ReadToEnd();

        var teams = GetTeams(text);

        using var writer = new StreamWriter(outStream);
        writer.Write("Team                           | MP |  W |  D |  L |  P");
        teams.ForEach(t => writer.Write(t.ToString()));

    }

    private static List<Team> GetTeams(string input)
    {
        Dictionary<string, Team> teams = [];
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
                    GetOrCreateTeam(teams, team1).Win();
                    GetOrCreateTeam(teams, team2).Lose();
                    break;
                case "loss":
                    GetOrCreateTeam(teams, team1).Lose();
                    GetOrCreateTeam(teams, team2).Win();
                    break;
                case "draw":
                    GetOrCreateTeam(teams, team1).Draw();
                    GetOrCreateTeam(teams, team2).Draw();
                    break;
            }
        }

        var sortedTeams = teams.Values
            .OrderByDescending(t => t.Points)
            .ThenBy(t => t.Name)
            .ToList();

        return sortedTeams;
    }

    private static Team GetOrCreateTeam(Dictionary<string, Team> teams, string name)
    {
        if (!teams.TryGetValue(name, out var team))
        {
            team = new Team(name);
            teams.Add(name, team);
        }
        return team;
    }
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

    public override string ToString() => $"\n{Name,-30} | {Played,2} | {Won,2} | {Drawn,2} | {Lost,2} | {Points,2}";
}
