using System;
using System.Collections.Generic;
using System.Linq;
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
        public Student(string name, string theme, DateTime date)
        {
            Name = name;
            Theme = theme;
            Date = date;
        }
    }
    public class Bachelor : Student
    {
        public int EducationPeriod { get; set; }

        public Bachelor(string name, string theme, DateTime date, string interest, int educationPeriod) : base(name, theme, date)
        {
            EducationPeriod = educationPeriod;
            Interest = interest;
        }
    }
    public class Master : Student
    {
        public string InternshipPlace { get; set; }
        public Master(string name, string theme, DateTime date, string interest, string internshipPlace) : base(name, theme, date)
        {
            InternshipPlace = internshipPlace;
            Interest = interest;
        }
    }
    public class Postgraduate : Student
    {
        public Postgraduate(string name, string theme, DateTime date) : base(name, theme, date)
        {

        }
    }
}

