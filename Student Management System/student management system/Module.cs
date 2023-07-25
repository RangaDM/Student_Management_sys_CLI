using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_management_system
{
    internal class Module
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public int CreditValue { get; set; }
        public double GradePoint { get; set; }

        public Module(int id, string name, string grade, int creditValue, double gradePoint)
        {
            ID = id;
            Name = name;
            Grade = grade;
            CreditValue = creditValue;
            GradePoint = gradePoint;
        }
    }
}
