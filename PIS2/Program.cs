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
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var students = Distribution.LoadStudents(@"C:\Users\Даша\source\repos\pis_repository\input.txt");
                ShowInformation.PrintInfo(students);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Не удалось найти текстовый файл");
                Console.WriteLine(ex);
            }
        }
    }
}



