using System.Collections.Generic;
using System.Linq;
using UserLogin;

namespace StudentInfoSystem;

public class StudentData
{
    private static List<Student> testStudents { get; } = new List<Student>();

    public static List<Student> testStudentsData()
    {
        Grades grade1 = new Grades(1, 2);
        Grades grade2 = new Grades(2, 3);
      //  List<Student> testStudents = new List<Student>();
        testStudents.Add(new Student("Dimitar", "Angelov", "Dimitrov",
            "FKST", "KSI", "mats", "ACTIVE", 1212201,
            "3", "10", "46", grade1));
        testStudents.Add(new Student("Angel", "Angelov", "Angelov",
           "FKST", "KSI", "mats", "ACTIVE", 1212201,
           "3", "10", "46", grade2));
        if (TestStudentsIfEmpty())
        {
            CopyTestStudents();
        }
        
        return testStudents;

    }

    private static bool TestStudentsIfEmpty()
    {
        StudentInfoContext context = new StudentInfoContext();
        IEnumerable<Student> queryStudents = context.Students;
        int countStudents = queryStudents.Count();


        return countStudents <= 0 ? true : false;
    }

    private static void CopyTestStudents()
    {
        StudentInfoContext context = new StudentInfoContext();
        foreach (Student st in testStudents)
        {
            context.Students.Add(st);
        }
        context.SaveChanges();
    }

    private static List<Student> GetRegions()
    {
        StudentInfoContext context = new StudentInfoContext();
        List<Student> students = context.Students.ToList();
        return students;
    }


}