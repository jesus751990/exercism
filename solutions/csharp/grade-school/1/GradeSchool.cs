public class GradeSchool
{
    private Dictionary<int, List<string>> schoolRecords = [];

    public bool Add(string student, int grade)
    {
        if (Roster().Contains(student))
            return false;
        if (schoolRecords.TryGetValue(grade, out var students))
            students.Add(student);
        else
            schoolRecords.Add(grade, [student]);
        return true;
    }

    public IEnumerable<string> Roster() => schoolRecords.Keys.Order().SelectMany(grade => schoolRecords[grade].Order().ToList());

    public IEnumerable<string> Grade(int grade) => schoolRecords.TryGetValue(grade, out var students) ? students.Order().ToArray() : [];
}