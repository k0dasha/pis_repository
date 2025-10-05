using System;
using System.Collections.Generic;
using System.IO;
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
        public Student(string input)
        {
            var parts = input.Split('"');

            Name = parts[1];
            Theme = parts[3];
            Date = DateTime.Parse(parts[parts.Length - 1].Replace("дата", ""));
        }
    }
    public class Bachelor : Student
    {
        public int EducationPeriod { get; set; }
        public Bachelor(string input) : base(input)
        {
            var parts = input.Split('"');

            if (parts.Length >= 6)
            {
                var periodStr = parts[5].Replace("срок", "");
                EducationPeriod = int.Parse(periodStr);
            }
        }
    }
    public class Master : Student
    {
        public string InternshipPlace { get; set; }
        public Master(string input) : base(input)
        {
            var parts = input.Split('"');
            if (parts.Length >= 6)
            {
                InternshipPlace = parts[5];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var students = LoadStudents("input.txt");
            PrintInfo(students);
        }
        static void PrintInfo(List<Student> students1)
        {
            foreach (var student in students1)
            {
                string info = ($"{student.Name}, {student.Theme}, {student.Date.ToString("yyyy.MM.dd")}");
                if (student is Bachelor b)
                {
                    Console.WriteLine(info + $" {b.EducationPeriod}");
                }
                else if (student is Master m)
                {
                    Console.WriteLine(info + $" {m.InternshipPlace}");
                }
            }
        }
        static List<Student> LoadStudents(string filePath)
        {
            var result = new List<Student>();

            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split(new char[] { ' ' });

                if (parts.Length > 3)
                {
                    if ((parts[5] as string) == null)
                    {
                        result.Add(new Bachelor(line));
                    }
                    else
                    {
                        result.Add(new Master(line));
                    }
                }
            }
            return result;
        }
    }
}


