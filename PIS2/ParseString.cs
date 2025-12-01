using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PIS2
{
    public static class StudentParser
    {
        public static string[] SplitText(string text)
        {
            return text.Split('"');
        }
        public static (string name, string theme, DateTime date) ParseBaseStudent(string text)
        {
            var parts = SplitText(text);
            if (parts.Length < 5)
                throw new ArgumentException("Недостаточно данных для базовой информации о студенте");

            string name = parts[1];
            string theme = parts[3];
            string strDate = parts[parts.Length - 1].Trim().Replace("дата", "");
            DateTime date = DateTime.Parse(strDate);

            return (name, theme, date);
        }
        public static Student ParsePostgraduate(string text)
        {
            try
            {
                string[] parts = SplitText(text);
                if (parts.Length != 5)
                    throw new ArgumentException("Некорректное количество данных для аспиранта");

                var (name, theme, date) = ParseBaseStudent(text);
                return new Postgraduate(name, theme, date);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка парсинга аспиранта: {ex.Message}");
                return null;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Ошибка парсинга аспиранта: {ex.Message}");
                return null;
            }
        }

        public static Student ParseBachelor(string text)
        {
            try
            {
                string[] parts = SplitText(text);

                if (parts.Length != 9)
                    throw new ArgumentException("Некорректное количество данных для бакалавра");

                var (name, theme, date) = ParseBaseStudent(text);
                var periodStr = parts[7].Replace("срок", "");

                if (!int.TryParse(periodStr, out int educationPeriod))
                    throw new FormatException($"Некорректный формат срока обучения: {periodStr}");

                string interest = parts[5];
                return new Bachelor(name, theme, date, interest, educationPeriod);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка парсинга бакалавра: {ex.Message}");
                return null;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Ошибка парсинга бакалавра: {ex.Message}");
                return null;
            }
        }

        public static Student ParseMaster(string text)
        {
            try
            {
                string[] parts = SplitText(text);
                if (parts.Length != 9)
                    throw new ArgumentException("Некорректное количество данных для магистра");

                var (name, theme, date) = ParseBaseStudent(text);
                string internshipPlace = parts[7];
                string interest = parts[5];

                return new Master(name, theme, date, interest, internshipPlace);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка парсинга магистра: {ex.Message}");
                return null;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Ошибка парсинга магистра: {ex.Message}");
                return null;
            }
        }
        public static int SumEvenNumbers(int to, int from, int[] ar)
        {

            int sum = 0;
            
            for (int i = ar[from]; i <= ar[to]; i++)
            {
                if (ar[i] % 2 == 0)
                {
                    sum += ar[i];
                    
                }
            }
            return sum;
            


            //int sum_section = section.Where(n => n % 2 == 0).Sum();
            //int sum = ar.Where(n => n % 2 == 0).Sum();
            //return sum_section;

        }
    }
}
