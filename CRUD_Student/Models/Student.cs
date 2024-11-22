namespace CRUD_Student.Models;

public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int BornedYear { get; set; }
    public string Gender { get; set; }
    public int Degree { get; set; }
    public string PhoneNumber { get; set; }
    public string Nationality { get; set; }



    public int GetAge(int year)
    {
        var age = 2024 - year;
        return age;
    }

    public void DisplayInfo()
    {
        var info = $"Id :{Id}FirstName :{FirstName}LastName :{LastName}BornedYear :{BornedYear}Gender :{Gender}Degree :{Degree}PhoneNumber :{PhoneNumber}Nationality :{Nationality}";
        Console.WriteLine(info);
    }
}
