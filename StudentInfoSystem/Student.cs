using System;
using System.Windows.Controls;
using System.Xml.Linq;

namespace StudentInfoSystem;

public class Student : IComparable<Student>
{
    public int StudentId { get; set; }
    public string name;
    public string middleName;
    public string lastName;
    public string faculty;
    public string specialty;
    public string education;
    public string status;
    public int facultyNumber;
    public string course;
    public string stream;
    public string group;
    public Grades grade;

    public Student()
    {
    }

    public Student(string name, string middleName, string lastName, string faculty, string specialty, string education, string status, int facultyNumber, string course, string stream, string group, Grades grade)
    {

        this.name = name;
        this.middleName = middleName;
        this.lastName = lastName;
        this.faculty = faculty;
        this.specialty = specialty;
        this.education = education;
        this.status = status;
        this.facultyNumber = facultyNumber;
        this.course = course;
        this.stream = stream;
        this.group = group;
        this.grade = grade;
    }

    public int CompareTo(Student other)
    {
        // Sort by name alphabetically, then by age
        int nameComparison = name.CompareTo(other.name);
        if (nameComparison != 0)
        {
            return nameComparison;
        }
        else
        {
            return group.CompareTo(other.group);
        }
    }
}