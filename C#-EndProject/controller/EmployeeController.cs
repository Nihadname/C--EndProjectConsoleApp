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
                helperForColor.changeTextColor(ConsoleColor.Red,MessagesForCases.ErroMessage);
            }
            else
            {
                helperForColor.changeTextColor(ConsoleColor.Green, MessagesForCases.MessagePartWhichIsForPositiveCases+"created");
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
                        streamWriter.WriteLine($"Name{emp.Name} SurName{emp.SurName} createdTime {emp.CreatedTime}");

                    }
                }
                foreach (Employee emp in employeeGetsAll)
                {
                    Console.WriteLine(emp);
                }
               
            }
            else
            {
                File.WriteAllText(filePath, MessagesForCases.MessagesForEmptyCases);
                helperForColor.changeTextColor(ConsoleColor.Red, MessagesForCases.MessagesForEmptyCases);
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
            if (Result.Count > 0)
            {
                foreach (var result in Result)
                {

                    helperForColor.changeTextColor(ConsoleColor.Green, $"{result.Name} {result.SurName}  {result.CreatedTime}");



                }
            }
            else
            {
                helperForColor.changeTextColor(ConsoleColor.Green, MessagesForCases.MessagesForEmptyCases);

            }

        }
        public void getById()
        {
            helperForColor.changeTextColor(ConsoleColor.Green, "reqem daxil edin");
            string number = Console.ReadLine();
            bool result = int.TryParse(number, out int GroupCount);
            var GettingById = employeeService.get(GroupCount);
            if(GettingById != null) {
                Console.WriteLine(GettingById);
            }
            else
            {
                helperForColor.changeTextColor(ConsoleColor.Green, MessagesForCases.MessageForCasesWhenIdDoesntMatch);

            }
        }
        public void GetAllWithAge()
        {
            helperForColor.changeTextColor(ConsoleColor.Green, "yasi daxil edin daxil edin");
            int age=int.Parse(Console.ReadLine());
            var Result=employeeService.GetAll(age);
            if (Result.Count > 0)
            {
                foreach (var result in Result)
                {
                    Console.WriteLine(result);
                }
            }
            else
            {
                helperForColor.changeTextColor(ConsoleColor.Green, MessagesForCases.MessagesForEmptyCases);

            }

        }
        public void GetAllWithDepartmentId()
        {
            helperForColor.changeTextColor(ConsoleColor.Green, "deparment id  daxil edin");
            byte Id = byte.Parse(Console.ReadLine());
            var Result=employeeService.GetAllWithDepartmentId(Id);
            if (Result != null)
            {
                if (Result.Count > 0)
                {
                    foreach (var result in Result)
                    {
                        Console.WriteLine(result);
                    }
                }
                else
                {
                    helperForColor.changeTextColor(ConsoleColor.Green, MessagesForCases.MessagesForEmptyCases);

                }
            }
            else
            {
                helperForColor.changeTextColor(ConsoleColor.Green, MessagesForCases.MessageForCasesWhenIdDoesntMatch);


            }
        }
     public void GetAllWithDepartmentName()
        {
            helperForColor.changeTextColor(ConsoleColor.Green, "ad daxil edin");
            string DepartmentName = Console.ReadLine();
            var Result=employeeService.GetAllWithDepartmentName(DepartmentName);
            if (Result.Count > 0)
            {
                foreach (var result in Result)
                {
                    Console.WriteLine(result);
                }
            }
            else
            {
                helperForColor.changeTextColor(ConsoleColor.Green, MessagesForCases.MessagesForEmptyCases);

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
            Console.WriteLine(count);
        }
        public void DeleteEmployee()
        {
            helperForColor.changeTextColor(ConsoleColor.Red, "enter Id");
            int id = int.Parse(Console.ReadLine());
            var result=employeeService.delete(id);
            if(result is null)
            {
                helperForColor.changeTextColor(ConsoleColor.Red, MessagesForCases.ErroMessage);
            }
            else
            {
                helperForColor.changeTextColor(ConsoleColor.Red, MessagesForCases.MessagePartWhichIsForPositiveCases+"deleted");

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
                helperForColor.changeTextColor(ConsoleColor.Red, MessagesForCases.ErroMessage);
            }
            else
            {
                helperForColor.changeTextColor(ConsoleColor.Green, MessagesForCases.MessagePartWhichIsForPositiveCases+" updated");

            }



        }

      
      public  void getAllWithSalary()
        {
            helperForColor.changeTextColor(ConsoleColor.Red, "Enter the number:");
            int number= int.Parse(Console.ReadLine());
            var result = employeeService.getAllWithSalary(number);
            if (result.Count > 0)
            {
                foreach (var emp in result)
                {
                    Console.WriteLine(emp);
                }
            }
            else
            {
                helperForColor.changeTextColor(ConsoleColor.Green, MessagesForCases.MessagesForEmptyCases);

            }
        }
    }
}
