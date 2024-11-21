using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EMPLOYEE MANAGEMENT SYSTEM");
            var crud = new crud();
            crud.Introduce();
        }
        public static void Option()
        {
            Console.WriteLine("\n=====OPTION=====");
            Console.WriteLine(" 1. Add Employee");
            Console.WriteLine(" 2. Read Employee");
            Console.WriteLine(" 3. Update Employee");
            Console.WriteLine(" 4. Delete Employee");
            Console.WriteLine(" 5. Exit");
        }
        public static void viewallorReadone()
        {
            Console.WriteLine(" 1. List All Employee");
            Console.WriteLine(" 2. Find Employee by ID");
        }
    }

}

namespace LINQ
{
    public class crud
    {
        List<Employee> employees = new List<Employee>();
        public int id, Choice;
        public string name, position, newSalary;
        public double salary;

        public void Introduce()
        {
            while (true)
            {
                Program.Option();
                Console.Write("Enter your choice: ");
                Choice = int.Parse(Console.ReadLine());

                switch (Choice)
                {
                    case 1:
                        ADD();
                        break;
                    case 2:
                        READ();
                        break;
                    case 3:
                        UPDATE();
                        break;
                    case 4:
                        DELETE();
                        break;
                    case 5:
                        Console.WriteLine("EXIT=========");
                        return;
                    default:
                        Console.WriteLine("PLease choose 1 to 5!!!");
                        break;
                }
            }
        }
        public void ADD()
        {

            Console.WriteLine("\n===ADD EMPLOYEE=====");
            Console.Write("Enter ID: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            name = Console.ReadLine();
            Console.Write("Enter Position: ");
            position = Console.ReadLine();
            Console.Write("Enter Salary: ");
            salary = double.Parse(Console.ReadLine());
            if (!employees.Any(e => e.Id == id))
            {
                employees.Add(new Employee { Id = id, Name = name, Position = position, Salary = salary });
                Console.WriteLine("Employees Added Succcessfully!!!");
            }
            else
            {
                Console.WriteLine("ID already Exist! ");
            }

        }
        public void READ()
        {

            Console.WriteLine("\n=======READ EMPLOYEE========");

            Console.Write("Enter your Choice: ");
            Choice = int.Parse(Console.ReadLine());
            if (Choice == 1)
            {
                Console.WriteLine("\n====LIST OF EMPLOYEES====");
                Console.WriteLine("\tID \tNAME POSITION SALARY");
                foreach (var em in employees)
                {
                    Console.WriteLine($"\t{em.Id}. \t{em.Name} \t{em.Position} \t\t{em.Salary}");

                }
            }


            else if (Choice == 2)
            {
                Console.Write("Search ID: ");
                id = int.Parse(Console.ReadLine());
                var employee = employees.FirstOrDefault(e => e.Id == id);
                if (employee != null)
                {
                    Console.WriteLine("========EMPLOYEE========");
                    Console.WriteLine("\tID \tNAME POSITION SALARY");
                    Console.WriteLine($"\t{employee.Id} \t{employee.Name} \t{employee.Position} \t\t{employee.Salary}");

                }
            }
            else
            {
                Console.WriteLine("Invalid!");
            }
        }
        public void UPDATE()
        {
            Console.WriteLine("\n============UPDATE======== ");
            Console.Write("Enter ID to Update: ");
            id = int.Parse(Console.ReadLine());

            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                Console.Write("Enter new Name(leave it blank if not going to update): ");
                name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) employee.Name = name;
                Console.Write("Enter new Position(leave it blank if not going to update): ");
                position = Console.ReadLine();
                if (!string.IsNullOrEmpty(position)) employee.Position = position;
                Console.Write("Enter new Position(leave it blank if not going to update): ");
                newSalary = Console.ReadLine();
                if (double.TryParse(newSalary, out double salary)) employee.Salary = salary;
                Console.WriteLine("Employee Updated Successfully!!!");
            }
            else
            {
                Console.WriteLine("ID not Found!!!");
            }
        }
        public void DELETE()
        {
            Console.WriteLine("\n====DELETE=====");
            Console.Write("Enter ID to Delete: ");
            id = int.Parse(Console.ReadLine());

            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine("Employee Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("ID not Found");
            }

        }
    }
}



namespace LINQ
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public double Salary { get; set; }

    }
}