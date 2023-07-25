using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Globalization;
using System.Runtime.InteropServices;
using student_management_system;

namespace student_management_system
{
    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkMagenta;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\n");
                Console.WriteLine("\t\t\t\t**************  Student Management System  **************\n");
                Console.WriteLine("\t\t\t\t\t\t-------------------------\t");
                Console.WriteLine("\t\t\t\t\t||\tMain Menu\t\t\t||");
                Console.WriteLine("\t\t\t\t\t||\t1. Add User\t\t\t||");
                Console.WriteLine("\t\t\t\t\t||\t2. Select User\t\t\t||");
                Console.WriteLine("\t\t\t\t\t||\t3. Delete User\t\t\t||");
                Console.WriteLine("\t\t\t\t\t||\t4. Display All Users\t\t||");
                Console.WriteLine("\t\t\t\t\t||\t5. Quit\t\t\t\t||");
                Console.WriteLine("\t\t\t\t\t\t-------------------------\t");
                Console.WriteLine();
                Console.Write("\n\t\t\t\t\tEnter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddUser();
                        break;
                    case 2:
                        SelectUser();
                        break;
                    case 3:
                        DeleteUser();
                        break; 
                    case 4:
                        DisplayAllUsers();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("\tInvalid choice.");
                        break;
                }
                Console.ReadKey();
            }
        }
        static void AddUser()
        {
            Console.Clear();
            Console.WriteLine("\n\tAdd User");
            Console.WriteLine();

            Console.Write("\tEnter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("\tEnter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("\tEnter Date of Birth (dd/MM/yyyy): ");
            DateTime dateOfBirth = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("\tEnter Address: ");
            string address = Console.ReadLine();

            int id = students.Count + 1;
            Student student = new Student(id, firstName, lastName, dateOfBirth, address);
            students.Add(student);

            Console.WriteLine("\tUser added successfully.");
        }

        static void SelectUser()
        {
            Console.Clear();
            Console.WriteLine("\n\tSelect User");
            Console.WriteLine();
            DisplayUsers();
            Console.WriteLine();

            Console.Write("\tEnter ID: ");
            int id = int.Parse(Console.ReadLine());

            Student student = students.Find(s => s.ID == id);
            if (student == null)
            {
                Console.WriteLine("\tUser not found.");
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\tUser Details");
                Console.WriteLine();
                Console.WriteLine($"\tID\t\t: {student.ID}");
                Console.WriteLine($"\tFirst Name\t: {student.FirstName}");
                Console.WriteLine($"\tLast Name\t: {student.LastName}");
                Console.WriteLine($"\tDate of Birth\t: {student.DateOfBirth.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"\tAddress\t\t: {student.Address}");
                Console.WriteLine();
                Console.WriteLine("\t\tOptions");
                Console.WriteLine("\t\t1. Modify User");
                Console.WriteLine("\t\t2. Add Modules");
                Console.WriteLine("\t\t3. Remove Modules");
                Console.WriteLine("\t\t4. Delete User");
                Console.WriteLine("\t\t5. Back");
                Console.WriteLine();
                Console.Write("\t\tEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ModifyUser(student);
                        break;
                    case 2:
                        AddModules(student);
                        break;
                    case 3:
                        RemoveModules(student);
                        break;
                    case 4:
                        DeleteUser(students);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("\t\t*Invalid choice*");
                        break;
                }
            }
        }

        private static void ModifyUser(Student student)
        {
            Console.WriteLine("\tEnter new First Name: ");
            student.FirstName = Console.ReadLine();
            Console.WriteLine("\tEnter new Last Name: ");
            student.LastName = Console.ReadLine();
            Console.WriteLine("\tEnter new Date of Birth (DD/MM/YYYY): ");
            student.DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("\tEnter new Address: ");
            student.Address = Console.ReadLine();

            Console.WriteLine("\tUser Modified Successfully");
        }

        private static void AddModules(Student student)
        {
            Console.WriteLine("\n\t\t\t*---Available Modules are---*");
            Console.WriteLine("\t\t\t# 3301 Analog Electronics");
            Console.WriteLine("\t\t\t# 3302 Data Structures and Algorithems");
            Console.WriteLine("\t\t\t# 3203 Measurement");
            Console.WriteLine("\t\t\t# 3305 Signal and Systems");
            Console.WriteLine("\t\t\t# 3251 GUI Prgramming");
            Console.WriteLine("\t\t\t# 3250 Programming  Project");

            Console.WriteLine("\tEnter Module ID: ");
            int moduleId = int.Parse(Console.ReadLine());
            Console.WriteLine("\tEnter Module Name: ");
            string moduleName = Console.ReadLine();
            Console.WriteLine("\tEnter Module Grade: ");
            string moduleGrade = Console.ReadLine();
            Console.WriteLine("\tEnter Credit Value: ");
            int creditValue = int.Parse(Console.ReadLine());
            Console.WriteLine("\tEnter Grade Point: ");
            int gradePoint = int.Parse(Console.ReadLine());

            student.Modules.Add(new Module(moduleId, moduleName, moduleGrade, creditValue, gradePoint));
            Console.WriteLine("\tModule Added Successfully");
        }

        private static void RemoveModules(Student student)
        {
            Console.WriteLine("\n\t\t\t*---Available Modules are---*");
            Console.WriteLine("\t\t\t# 3301 Analog Electronics");
            Console.WriteLine("\t\t\t# 3302 Data Structures and Algorithems");
            Console.WriteLine("\t\t\t# 3203 Measurement");
            Console.WriteLine("\t\t\t# 3305 Signal and Systems");
            Console.WriteLine("\t\t\t# 3251 GUI Prgramming");
            Console.WriteLine("\t\t\t# 3250 Programming  Project");

            Console.WriteLine("\tEnter Module ID to remove: ");
            int moduleId = int.Parse(Console.ReadLine());

            Module module = student.Modules.Find(x => x.ID == moduleId);
            if (module == null)
            {
                Console.WriteLine("\tModule not found");
                return;
            }
            student.Modules.Remove(module);
            Console.WriteLine("\tModule removed Successfully");
        }
        private static void DeleteUser(List<Student> students)
        {
            DisplayUsers();
            Console.WriteLine("\tEnter the ID of the student you want to delete:");
            int id = int.Parse(Console.ReadLine());

            Student studentToDelete = students.Find(s => s.ID == id);
            if (studentToDelete != null)
            {
                Console.WriteLine("\tAre you sure you want to delete the following student?");
                Console.WriteLine("\tID: " + studentToDelete.ID);
                Console.WriteLine("\tFirst Name: " + studentToDelete.FirstName);
                Console.WriteLine("\tLast Name: " + studentToDelete.LastName);
                Console.WriteLine("\tDate of Birth: " + studentToDelete.DateOfBirth.ToShortDateString());
                Console.WriteLine("\tAddress: " + studentToDelete.Address);

                Console.WriteLine("\tEnter 'yes' to confirm or 'no' to cancel:");
                string confirm = Console.ReadLine();
                if (confirm.ToLower() == "yes")
                {
                    students.Remove(studentToDelete);
                    int ID = students.Count + 1;
                    Console.WriteLine("\tThe student has been deleted.");
                }
                else
                {
                    Console.WriteLine("\tThe student was not deleted.");
                }
            }
            else
            {
                Console.WriteLine("\tA student with ID " + id + " was not found.");
            }
        }

        private static void DeleteUser()
        {
            DisplayUsers();
            Console.WriteLine("\n\tEnter the ID of the student you want to delete:");
            int id = int.Parse(Console.ReadLine());
            Student student = students.Find(s => s.ID == id);
            if (student != null)
            {
                Console.WriteLine("\tStudent details:");
                Console.WriteLine("\tID: " + student.ID);
                Console.WriteLine("\tFirst Name: " + student.FirstName);
                Console.WriteLine("\tLast Name: " + student.LastName);
                Console.WriteLine("\tDate of Birth: " + student.DateOfBirth.ToShortDateString());
                Console.WriteLine("\tAddress: " + student.Address);
                Console.WriteLine("\tAre you sure you want to delete this student? (Y/N)");
                string confirmation = Console.ReadLine();
                if (confirmation.ToLower() == "y")
                {
                    students.Remove(student);
                    int ID = students.Count + 1;
                    Console.WriteLine("\tStudent has been deleted.");
                }
                else
                {
                    Console.WriteLine("\tDelete operation has been cancelled.");
                }
            }
            else
            {
                Console.WriteLine("\tNo student found with the given ID.");
            }
        }

        private static void DisplayUsers()
        {
            Console.WriteLine("\n\tID\tFirst Name\tLast Name");
            foreach (var student in students)
            {
                Console.WriteLine("\t" + student.ID + "\t" + student.FirstName + "\t\t" + student.LastName);
            }
        }

        private static void DisplayAllUsers()
        {
            // Code for displaying all users
            Console.WriteLine("\n\tID\tFirst Name\tLast Name\tDate of Birth\t\tGPA");
            foreach (var student in students)
            {
                Console.WriteLine("\t" + student.ID + "\t" + student.FirstName + "\t\t" + student.LastName + "\t\t" +
                                  student.DateOfBirth.ToShortDateString() + "\t\t" + student.GetGPA());
            }
        }
    }
}

