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
    public class DepartmentController
    {
        private readonly DepartmentService departmentService;
        public DepartmentController()
        {
            departmentService = new DepartmentService();
        }
        public void createDepartment()
        {
            helperForColor.changeTextColor(ConsoleColor.Green, "department ad daxil edin");

            string DepartmentName = Console.ReadLine();
            helperForColor.changeTextColor(ConsoleColor.Yellow, "enter student size");
            string size = Console.ReadLine();
            bool result = int.TryParse(size, out int GroupSize);



            if (result)
            {
                Department department = new Department();
                department.Name = DepartmentName;
                department.Capacity = GroupSize;
                var createdgroup =departmentService.Create(department);
                if(createdgroup != null)
                {
                    helperForColor.changeTextColor(ConsoleColor.Yellow, $"{department.Name}  is created succesfully");
                }
                else
                {
                    helperForColor.changeTextColor(ConsoleColor.Red, "something went wrong");
                }
            }
            else
            {
                helperForColor.changeTextColor(ConsoleColor.Red, "write size of group properly"); ;

            }
        }
        public void GetAllDepartment(){


            helperForColor.changeTextColor(ConsoleColor.Green, "Deparment list:");
            var DepartmentGetsAll = departmentService.GetAll();
            string filePath = @"C:\Users\nihad\OneDrive\Desktop\ProjectDataCollector\Data1.txt";
            if (DepartmentGetsAll.Count > 0)
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    foreach (var emp in DepartmentGetsAll)
                    {
                        streamWriter.WriteLine($"Name{emp.Name} SurName{emp.Capacity}");

                    }
                }
                foreach (var emp in DepartmentGetsAll)
                {
                    Console.WriteLine(emp);
                }

            }
            else
            {
                File.WriteAllText(filePath, "Empty list");
                helperForColor.changeTextColor(ConsoleColor.Red, "Empty list");
            }

        }
        public void GetWithName() {
            helperForColor.changeTextColor(ConsoleColor.Green, "ad daxil edin");
            string Name = Console.ReadLine();
            var Result = departmentService.Get(Name);
            Console.WriteLine(Result);
        }
        public void GetDepartmentById()
        {
            helperForColor.changeTextColor(ConsoleColor.Green, "reqem daxil edin");
            string number = Console.ReadLine();
            bool result = int.TryParse(number, out int GroupCount);
            var GettingById = departmentService.Get(GroupCount);
            Console.WriteLine(GettingById);
                if(GettingById == null)
            {
                helperForColor.changeTextColor(ConsoleColor.Red, "bele bir department id yoxdur");

            }

        }
    }
}