public static class Languages
{
    public static List<string> NewList() => [];

    public static List<string> GetExistingLanguages() => ["C#", "Clojure", "Elm"];

    public static List<string> AddLanguage(List<string> languages, string language) => [.. languages, language];

    public static int CountLanguages(List<string> languages) => languages.Count;

    public static bool HasLanguage(List<string> languages, string language) => languages.Contains(language);

    public static List<string> ReverseList(List<string> languages) => [.. languages.Reverse<string>()];

    public static bool IsExciting(List<string> languages) => languages.Count != 0 && languages[0] is "C#" || languages.Count > 1 && languages[1] is "C#" && languages.Count < 4;

    public static List<string> RemoveLanguage(List<string> languages, string language) => [.. languages.Where(l => l != language)];

    public static bool IsUnique(List<string> languages) => languages.Distinct().Count() == languages.Count;
}
