using C__EndProject.Business.interfaces;
using C__EndProject.Business.Services;
using C__EndProject.Domain;
using C__EndProject.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__EndProject.controller
{
   public class EmployeeController
    {
        private readonly EmployeeService employeeService;
        public EmployeeController()
        {
            employeeService = new EmployeeService();
        }
        public void CreateEmployee()
        {
           helperForColor.changeTextColor(ConsoleColor.Green,"ad daxil edin");
            string name=Console.ReadLine();
            helperForColor.changeTextColor(ConsoleColor.Green, "soy ad daxil edin");
            string SurName=Console.ReadLine();
            helperForColor.changeTextColor(ConsoleColor.Green, "department ad daxil edin");
            string departmentName=Console.ReadLine();
            helperForColor.changeTextColor(ConsoleColor.Green, "address daxil edin");
            string address= Console.ReadLine();
            helperForColor.changeTextColor(ConsoleColor.Green, "age daxil edin");
            int age =int.Parse(Console.ReadLine());
            helperForColor.changeTextColor(ConsoleColor.Green, "salary daxil edin");
            int salary = int.Parse(Console.ReadLine());


            Employee employee = new Employee();
            employee.Name = name;
            employee.SurName = SurName;
            employee.address = address;
            employee.age = age;
            employee.Salary = salary;
            if(employeeService.Create(employee,departmentName) is null) {
                helperForColor.changeTextColor(ConsoleColor.Red, "something went wrong");
            }
            else
            {
                helperForColor.changeTextColor(ConsoleColor.Green, "succesfully created");
                employeeService.HireEmployeeAndUpdateRevenue(employee); // Hire the employee and adjust revenue

            }


        }
        public void GetAllEmployee()
        {
            helperForColor.changeTextColor(ConsoleColor.Green, "Employee list:");
            var employeeGetsAll = employeeService.GetAll();
            string filePath = @"C:\Users\nihad\OneDrive\Desktop\ProjectDataCollector\Data.txt";
            if (employeeGetsAll.Count > 0)
            {
                using(StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    foreach (Employee emp in employeeGetsAll)
                    {
                        streamWriter.WriteLine($"Name{emp.Name} SurName{emp.SurName}");

                    }
                }
                foreach (Employee emp in employeeGetsAll)
                {
                    Console.WriteLine(emp);
                }
               
            }
            else
            {
                File.WriteAllText(filePath, "Empty list");
                helperForColor.changeTextColor(ConsoleColor.Red, "Empty list");
            }


            //if (File.Exists(filePath))
            //{
            //    try
            //    {
            //        Process.Start(filePath);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("An error occurred while opening the file: " + ex.Message);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("File does not exist.");
            //}
        }
        public void GetAllWithNames()
        {
            helperForColor.changeTextColor(ConsoleColor.Green, "ad daxil edin");
            string Name = Console.ReadLine();
            var Result= employeeService.GetAll(Name); 
            foreach(var  result in Result)
            {
          
                    helperForColor.changeTextColor(ConsoleColor.Green, $"{result.Name} {result.SurName}");
                


            }


        }
        public void getById()
        {
            helperForColor.changeTextColor(ConsoleColor.Green, "reqem daxil edin");
            string number = Console.ReadLine();
            bool result = int.TryParse(number, out int GroupCount);
            var GettingById = employeeService.get(GroupCount);
            Console.WriteLine(GettingById);
        }
        public void GetAllWithAge()
        {
            helperForColor.changeTextColor(ConsoleColor.Green, "yasi daxil edin daxil edin");
            int age=int.Parse(Console.ReadLine());
            var Result=employeeService.GetAll(age);
            foreach( var result in Result)
            {
                Console.WriteLine(result);
            }

        }
        public void GetAllWithDepartmentId()
        {
            helperForColor.changeTextColor(ConsoleColor.Green, "deparment id  daxil edin");
            byte Id = byte.Parse(Console.ReadLine());
            var Result=employeeService.GetAllWithDepartmentId(Id);
            foreach( var result in Result)
            {
                Console.WriteLine(result);
            }
        }
     public void GetAllWithDepartmentName()
        {
            helperForColor.changeTextColor(ConsoleColor.Green, "ad daxil edin");
            string DepartmentName = Console.ReadLine();
            var Result=employeeService.GetAllWithDepartmentName(DepartmentName);
            foreach( var result in Result)
            {
                Console.WriteLine(result);
            }
        }
        public void GetAllEmployeesCount()
        {
       var result=employeeService.GetCount();
            Console.WriteLine(result);
        }
        public void GetAllEmployeesCountById()
        {
            helperForColor.changeTextColor(ConsoleColor.Red, "enter Id");
            byte id = byte.Parse(Console.ReadLine());

            int count = employeeService.GetCount(id);
        }
        public void DeleteEmployee()
        {
            helperForColor.changeTextColor(ConsoleColor.Red, "enter Id");
            int id = int.Parse(Console.ReadLine());
            var result=employeeService.delete(id);
            if(result is null)
            {
                helperForColor.changeTextColor(ConsoleColor.Red, "something went wrong");
            }
            else
            {
                helperForColor.changeTextColor(ConsoleColor.Red, "deleted");

            }

        }
       public void UpdateEmployee()
        {

            helperForColor.changeTextColor(ConsoleColor.Red, "enter Id");
            int id = int.Parse(Console.ReadLine());
            helperForColor.changeTextColor(ConsoleColor.Red, "enter new employee Name");
            string name = Console.ReadLine();
            helperForColor.changeTextColor(ConsoleColor.Yellow, "enter new employee SurName");
            string Surname = Console.ReadLine();
            helperForColor.changeTextColor(ConsoleColor.Green, "enter DepartmentName ");
            string Departmentname = Console.ReadLine();
            helperForColor.changeTextColor(ConsoleColor.Green, "enter employee adress ");
            string adrress = Console.ReadLine();
            helperForColor.changeTextColor(ConsoleColor.Red, "enter new salary");
            int salary=int.Parse(Console.ReadLine());

            Employee employee = new Employee();
            employee.Name = name;
            employee.SurName = Surname;
            employee.address = adrress;
            employee.Salary = salary;

            if(employeeService.Update(id, employee,Departmentname) is null) {
                helperForColor.changeTextColor(ConsoleColor.Red, "something went wrong");
            }
            else
            {
                helperForColor.changeTextColor(ConsoleColor.Green, "succesfully updated");

            }



        }

        public void GeneralRevenueController()
        {
            helperForColor.changeTextColor(ConsoleColor.Red, "Enter the number of months to simulate:");

            int number = int.Parse(Console.ReadLine());

            employeeService.GeneralRevenueController(number); // Simulate time passing and update revenue

            // You can optionally print or log the results here
            Console.WriteLine("Simulation completed for " + number + " months.");
            List<Employee> employees = employeeService.GetAll();
            
            foreach (var emp in employees)
            {
                Console.WriteLine($"Employee: {emp.Name} {emp.SurName}, Salary: {emp.Salary}");
            }
            // You might also consider showing the updated revenue if it's accessible from the service layer
            Console.WriteLine("Updated revenue: " + employeeService.GetUpdatedRevenue());
        }
      public  void getAllWithSalary()
        {
            helperForColor.changeTextColor(ConsoleColor.Red, "Enter the number:");
            int number= int.Parse(Console.ReadLine());
            var result = employeeService.getAllWithSalary(number);
            foreach( var emp in result)
            {
                Console.WriteLine(emp);
            }

        }
    }
}
