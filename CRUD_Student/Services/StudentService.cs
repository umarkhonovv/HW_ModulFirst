using CRUD_Student.Models;

namespace CRUD_Student.Services;

public class StudentService
{
    private List<Student> students;

    public StudentService()
    {
        students = new List<Student>();
        DataSeed();
    }

    public Student AddStudent(Student student)
    {
        student.Id = Guid.NewGuid();
        students.Add(student);
        return student;
    }

    public bool DeleteStudent(Guid studentId)
    {
        var exists = false;
        foreach (var student in students)
        {
            if (student.Id == studentId)
            {
                students.Remove(student);
                exists = true;
                break;
            }
        }
        return exists;
    }

    public bool UpdateStudent(Student updatedStudent)
    {
        for (var i = 0; i < students.Count; i++)
        {
            if (students[i].Id == updatedStudent.Id)
            {
                students[i] = updatedStudent;
                return true;
            }
        }
        return false;
    }

    public Student GetById(Guid studentId)
    {
        foreach (var student in students)
        {
            if (student.Id == studentId)
            {
                return student;
            }
        }
        return null;
    }

    public List<Student> GetAllStudents()
    {
        return students;
    }


    private void DataSeed()
    {
        var student = new Student()
        {
            Id = Guid.NewGuid(),
            FirstName = "Unknown",
            LastName = "Unknown",
            BornedYear = 0000,
            Gender = "Male or Famale",
            Degree = 1,
            PhoneNumber = "+998999999999",
            Nationality = "Uzbek"
        };
        students.Add(student);
    }
}
