using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PIS2
{
    public static class Distribution
    {
        public static List<Student> LoadStudents(string filePath)
        {
            var result = new List<Student>();

            foreach (var line in File.ReadLines(filePath))
            {
                var student = CallParseStudent(line);
                if (student != null)
                    result.Add(student);
            }
            return result;
        }
        public static Student CallParseStudent(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            if (text.Contains("Срок"))
            {
                return StudentParser.ParseBachelor(text);
            }
            else if (text.Contains("Стажировка"))
            {
                return StudentParser.ParseMaster(text);
            }
            else
                return StudentParser.ParsePostgraduate(text);
        }
    }
}
