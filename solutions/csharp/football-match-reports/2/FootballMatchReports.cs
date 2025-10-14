public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum) => shirtNum switch
    {
        1 => "goalie",
        2 => "left back",
        3 or 4 => "center back",
        5 => "right back",
        6 or 7 or 8 => "midfielder",
        9 => "left wing",
        10 => "striker",
        11 => "right wing",
        _ => "UNKNOWN",
    };

    public static string AnalyzeOffField(object report) => report switch
    {
        string message => message,
        int supporters => $"There are {supporters} supporters at the match.",
        Manager manager => string.IsNullOrEmpty(manager.Club) ? manager.Name : $"{manager.Name} ({manager.Club})",
        Foul foul => foul.GetDescription(),
        Injury injury => $"Oh no! {injury.GetDescription()}. Medics are on the field.",
        Incident incident => incident.GetDescription(),
        _ => string.Empty,
    };
}
