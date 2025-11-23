using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS2
{
    public static class ShowInformation
    {
        public static void PrintInfo(List<Student> studentsList)
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
                Console.WriteLine($"Бакалавр\n{info}\n{b.EducationPeriod}\n{student.Interest}\n");
            else if (student is Master m)
                Console.WriteLine($"Магистр\n{info}\n{m.InternshipPlace}\n{student.Interest}\n");
            else
                Console.WriteLine($"Аспирант\n{info}\n");
        }
    }
}
