using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_management_system
{
    internal class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public List<Module> Modules { get; set; }

        public Student(int id, string firstName, string lastName, DateTime dateOfBirth, string address)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;
            Modules = new List<Module>();
        }

        public Student(string v1, string v2, DateTime dateTime, string v3)
        {
        }

        public Student(string v1, string v2, int v3, string v4)
        {
        }

        public double GetGPA()
        {
            if (Modules == null || Modules.Count == 0)
            {
                return 0;
            }

            double totalGradePoints = 0;
            int totalCreditValue = 0;
            foreach (var module in Modules)
            {
                totalGradePoints += module.GradePoint * module.CreditValue;
                totalCreditValue += module.CreditValue;
            }

            return totalGradePoints / totalCreditValue;
        }
    }
}
