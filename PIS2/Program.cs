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
        public void ParseString(string input)
        {
            var parts = input.Split('"');

            Name = parts[1];
            Theme = parts[3];
            Date = DateTime.Parse(parts[4].Replace("дата ", ""));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string data = "Студент \"Кузьмин Д.\" Тема \"Логарифмы\" дата 2025.09.09";

            Student st = new Student();
            st.ParseString(data);

            Console.WriteLine(st.Name);
            Console.WriteLine(st.Theme);
            Console.WriteLine(st.Date.ToString("yyyy.MM.dd"));
        }
    }
}


