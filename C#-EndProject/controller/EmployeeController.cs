using C__EndProject.Business.Services;
using C__EndProject.Domain;
using C__EndProject.Helpers;
using System;
using System.Collections.Generic;
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
            Employee employee = new Employee();
            employee.Name = name;
            employee.SurName = SurName;
            employee.address = address;
            if(employeeService.Create(employee,departmentName) is null) {
                helperForColor.changeTextColor(ConsoleColor.Red, "something went wrong");
            }
            else
            {
                helperForColor.changeTextColor(ConsoleColor.Green, "succesfully created");

            }


        }
        public void getAllEmployee() {
            helperForColor.changeTextColor(ConsoleColor.Green, "employee lis:");
            var employeeGetsAll=employeeService.GetAll();
            if(employeeGetsAll.Count>0) {
                foreach( Employee emp in employeeGetsAll) {

                    helperForColor.changeTextColor(ConsoleColor.Green, $"Name {emp.Name} SurName{emp.SurName} address{emp.address} departmentName {emp.department.Name}");

                }

            }
            else
            {
                helperForColor.changeTextColor(ConsoleColor.Red, "empty lis");

            }



        }

    }
}
