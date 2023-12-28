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

            Employee employee = new Employee();
            employee.Name = name;
            employee.SurName = SurName;
            employee.address = address;
            employee.age = age;
            if(employeeService.Create(employee,departmentName) is null) {
                helperForColor.changeTextColor(ConsoleColor.Red, "something went wrong");
            }
            else
            {
                helperForColor.changeTextColor(ConsoleColor.Green, "succesfully created");

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
               
            }
            else
            {
                File.WriteAllText(filePath, "Empty list");
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

    }
 }
