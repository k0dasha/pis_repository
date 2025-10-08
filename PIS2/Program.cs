using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PIS2
{
    public abstract class Student
    {
        public string Name { get; set; }
        public string Theme { get; set; }
        public DateTime Date { get; set; }
        public string Interest { get; set; }
        public virtual void ParseString(string input)
        {
            var parts = input.Split('"');

            Name = parts[1];
            Theme = parts[3];
            Interest = parts[5];
            Date = DateTime.Parse(parts[parts.Length - 1].Replace("дата", ""));
        }
        public Student(string input)
        {
            ParseString(input);
        }
    }
    public class Bachelor : Student
    {
        public int EducationPeriod { get; set; }
        public override void ParseString(string input)
        {
            var parts = input.Split('"');
            Name = parts[1];
            Theme = parts[3];
            Interest = parts[5];
            Date = DateTime.Parse(parts[parts.Length - 1].Replace("дата", ""));

            if (parts.Length >= 9)
            {
                var periodStr = parts[7].Replace("срок", "");
                EducationPeriod = int.Parse(periodStr);
            }
        }
        public Bachelor(string input) : base(input)
        {
            ParseString(input);
        }
    }
    public class Master : Student
    {
        public string InternshipPlace { get; set; }
        public override void ParseString(string input)
        {
            var parts = input.Split('"');
            Name = parts[1];
            Theme = parts[3];
            Interest = parts[5];
            Date = DateTime.Parse(parts[parts.Length - 1].Replace("дата", ""));

            if (parts.Length >= 9)
            {
                InternshipPlace = parts[7];
            }
        }
        public Master(string input) : base(input)
        {
            ParseString(input);
        }
    }
    public class Postgraduate : Student
    {
        public override void ParseString(string input)
        {
            var parts = input.Split('"');
            Name = parts[1];
            Theme = parts[3];
            Date = DateTime.Parse(parts[parts.Length - 1].Replace("дата", ""));
        }
        public Postgraduate(string input) : base(input)
        {
            ParseString(input);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var students = LoadStudents(@"C:\Users\Даша\source\repos\pis_repository\input.txt");
            PrintInfo(students);
        }
        static void PrintInfo(List<Student> studentsList)
        {
            foreach (var student in studentsList)
            {
                PrintStudent(student);
            }
        }
        static void PrintStudent(Student student)
        {
            string info = $"{student.Name}\n{student.Theme}\n{student.Date:yyyy.MM.dd}";

            if (student is Bachelor b)
                Console.WriteLine($"\n{info}{b.EducationPeriod}\n{student.Interest}\n");
            else if (student is Master m)
                Console.WriteLine($"\n{info}\n{m.InternshipPlace}\n{student.Interest}\n");
            else
                Console.WriteLine($"{info}");
        }
        static List<Student> LoadStudents(string filePath)
        {
            var result = new List<Student>();

            foreach (var line in File.ReadLines(filePath))
            {
                var student = ParseStudent(line);
                if (student != null)
                    result.Add(student);
            }
            return result;
        }
        static Student ParseStudent(string line)
        {
            var parts = line.Split(new char[] { ' ' });

            if (parts.Length <= 7)
            {
                return (new Postgraduate(line));
            }
            else
            {
                if ((parts[6] as string) == null)
                {
                    return (new Bachelor(line));
                }
                else
                {
                    return (new Master(line));
                }
            }
        }
    }
}



