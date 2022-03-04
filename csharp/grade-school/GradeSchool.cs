using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{

    private readonly Dictionary<int, IList<string>> _roster = 
        new Dictionary<int, IList<string>>();
    public void Add(string student, int grade)
    {
        if (_roster.ContainsKey(grade))
        {
            _roster[grade].Add(student);
        }
        else
        {
            _roster[grade] = new List<string>{ student };
        }
    }

    public IEnumerable<string> Roster()
    {        
        var grades =_roster.Keys.OrderBy(x => x);
        var students = new List<string>();
        foreach (var grade in grades)
        {
            students.AddRange(_roster[grade].OrderBy(x => x));
        }
        return students;
    }

    public IEnumerable<string> Grade(int grade)
    {
        return _roster.TryGetValue(grade, out var students) ? students.OrderBy(x => x).ToArray() : Array.Empty<string>();
    }
}