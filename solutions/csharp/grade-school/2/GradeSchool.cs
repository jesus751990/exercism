public class GradeSchool
{
    private Dictionary<int, string> schoolRecords = [];

    public bool Add(string student, int grade) => schoolRecords.TryAdd(grade, student);

    public IEnumerable<string> Roster() => schoolRecords.OrderBy(r => r.Key).ThenBy(r => r.Value).Select(s => s.Value);

    public IEnumerable<string> Grade(int grade) => schoolRecords.Where(sr => sr.Key == grade).OrderBy(r => r.Value).Select(s => s.Value);
}