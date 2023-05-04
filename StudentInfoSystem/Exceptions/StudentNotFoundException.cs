using System;

namespace StudentInfoSystem.Exceptions;

public class StudentNotFoundException: Exception
{
    public StudentNotFoundException(string message):base(message)
    {
        
    }
}