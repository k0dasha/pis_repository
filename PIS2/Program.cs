using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PIS2
{
    public class Student
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
            string data = "Студент \"Кузьмин Д.\" Тема \"Логарифмы\" дата 2025.09.09";
            string data_1 = "Студент \"Воскресенская Л.\" Тема \"Интерфейсы\" дата 2025.10.30";
            string data_2 = "Студент \"Афанасьев М.\" Тема \"Совместные события\" срок \"2\" дата 2025.01.01";

            Student st = new Student(data);

            Console.WriteLine(st.Name);
            Console.WriteLine(st.Theme);
            Console.WriteLine(st.Date.ToString("yyyy.MM.dd"));
            Console.WriteLine();

            Master stu = new Master(data_1);
            Console.WriteLine(stu.Name);
            Console.WriteLine(stu.Theme);
            Console.WriteLine(stu.Date.ToString("yyyy.MM.dd"));
            Console.WriteLine(stu.InternshipPlace);
            Console.WriteLine();

            Bachelor stud = new Bachelor(data_2);
            Console.WriteLine(stud.Name);
            Console.WriteLine(stud.Theme);
            Console.WriteLine(stud.Date.ToString("yyyy.MM.dd"));
        }
    }
}


