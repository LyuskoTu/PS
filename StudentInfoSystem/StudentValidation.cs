using System;
using System.Collections.Generic;
using System.Linq;
using StudentInfoSystem.Exceptions;
using UserLogin;

namespace StudentInfoSystem;

public class StudentValidation
{
    public Student GetStudentDataByUser(User user)
    {
        List<Student> students = StudentData.testStudentsData();
        return students.Find(s => (s.facultyNumber == user.facultyNumber)) ??
               throw new StudentNotFoundException("Student with faculty number: " + user.facultyNumber + " not found!");
    }

  
}