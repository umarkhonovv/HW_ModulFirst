using CRUD_Student.Models;
using CRUD_Student.Services;

namespace CRUD_Student
{
    public class Program
    {
        static void Main(string[] args)
        {
            RunFrontEnd();
        }

        public static void RunFrontEnd()
        {
            var studentService = new StudentService();


            while (true)
            {
                Console.WriteLine("1.Add a student");
                Console.WriteLine("2.Delete the student");
                Console.WriteLine("3.Update the student informations");
                Console.WriteLine("4.Show the student");
                Console.WriteLine("5.Show all students");
                Console.Write("Enter :");

                var option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    var student = new Student();
                    Console.Write("Enter the first name :");
                    student.FirstName = Console.ReadLine();
                    Console.Write("Enter the second name :");
                    student.LastName = Console.ReadLine();
                    Console.Write("Enter the borned year of the student :");
                    student.BornedYear = int.Parse(Console.ReadLine());
                    Console.Write("Enter the gender of the student :");
                    student.Gender = Console.ReadLine();
                    Console.Write("Enter the degree of the student :");
                    student.Degree = int.Parse(Console.ReadLine());
                    Console.Write("Enter the phone number of the student :");
                    student.PhoneNumber = Console.ReadLine();
                    Console.Write("Enter the nationality of the student :");
                    student.Nationality = Console.ReadLine();

                    studentService.AddStudent(student);
                    Console.Write("The student succesfully added to the list of students");
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter the id to delete student :");
                    var studentId = Guid.Parse(Console.ReadLine());
                    var result = studentService.DeleteStudent(studentId);
                    if (result is true)
                    {
                        Console.WriteLine("The student succesfully deleted from the list of students");
                    }
                    else
                    {
                        Console.WriteLine("There is no such student in the list of students");
                    }
                }
                else if (option == 3)
                {
                    var student = new Student();

                    Console.Write("Enter id to update : ");
                    student.Id = Guid.Parse(Console.ReadLine());
                    Console.Write("Enter the first name :");
                    student.FirstName = Console.ReadLine();
                    Console.Write("Enter the second name :");
                    student.LastName = Console.ReadLine();
                    Console.Write("Enter the borned year of the student :");
                    student.BornedYear = int.Parse(Console.ReadLine());
                    Console.Write("Enter the gender of the student :");
                    student.Gender = Console.ReadLine();
                    Console.Write("Enter the degree of the student :");
                    student.Degree = int.Parse(Console.ReadLine());
                    Console.Write("Enter the phone number of the student :");
                    student.PhoneNumber = Console.ReadLine();
                    Console.Write("Enter the nationality of the student :");
                    student.Nationality = Console.ReadLine();

                    var result = studentService.UpdateStudent(student);

                    if (result is true)
                    {
                        Console.WriteLine("The student succesfully updated");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong!");
                    }
                }
                else if (option == 4)
                {
                    Console.Write("Enter id to get : ");
                    var id = Guid.Parse(Console.ReadLine());
                    var student = studentService.GetById(id);
                    if (student is null)
                    {
                        Console.WriteLine("There is no such student in the list of students");
                    }
                    else
                    {
                        student.DisplayInfo();
                    }
                }
                else if (option == 5)
                {
                    var students = studentService.GetAllStudents();
                    foreach (var student in students)
                    {
                        student.DisplayInfo();
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
