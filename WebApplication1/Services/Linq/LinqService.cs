using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Services.Linq
{
    // Clasa Student cu 5 proprietăți
    public class Student
    {
        public Student(int id, string name, int age, string group, double nota, string email)
        {
            Id = id;
            Name = name;
            Age = age;
            Group = group;
            Nota = nota;
            Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public double Nota { get; set; }
        public string Email { get; set; }
    }

    // Clasa statica ce conține lista de obiecte
    public static class StudentStorage
    {
        public static List<Student> Students { get; } = new List<Student>
        {
            new Student(1, "Ana", 22, "M5331", 9.3, "ana@gmail.com"),
            new Student(2, "Bogdan", 25, "M534", 8.5, "bogdan@gmail.com"),
            new Student(3, "Cristina", 20, "M533", 9.8, "cris@gmail.com"),
            new Student(4, "Dan", 28, "M535", 7.9, "dan@gmail.com"),
            new Student(5, "Elena", 21, "M534", 9.1, "elena@gmail.com")
        };
    }

    public class LinqService : ILinqService
    {

        public int CountStudentsOver_Method(int value)
        {
            return StudentStorage.Students.Count(student => student.Age >= value);
        }

        //Query care returnează numărul de elemente
        public int CountStudentsOver_Query(int value)
        {
            var query = from student in StudentStorage.Students
                        where student.Age >= value
                        select student;

            return query.Count();
        }
        // Query care returneaza o lista de obiecte folosind where
        public List<Student> FilterByGroup(string groupName)
        {
            var query = from s in StudentStorage.Students
                        where s.Group == groupName
                        select s;

            return query.ToList();
        }

        // Query care returneaza o lista de stringuri (o proprietate)
        public List<string> SelectEmails()
        {
            return StudentStorage.Students.Select(student => student.Email).ToList();
        }

        // query unde se foloseste Where(method-based)
        public List<Student> FilterByNota(double minNota)
        {
            return StudentStorage.Students.Where(student => student.Nota >= minNota).ToList();
        }

        //query unde se foloseste Join
        public List<string> JoinWithGroups()
        {
            var groups = new List<(string GroupCode, string Specialization)>
            {
                ("M533", "Informatica"),
                ("M534", "Matematica"),
                ("M535", "Fizica")
            };

            var query = from student in StudentStorage.Students
                        join groupInfo in groups on student.Group equals groupInfo.GroupCode
                        select $"{student.Name} - {groupInfo.Specialization}";

            return query.ToList();
        }
    }
}
