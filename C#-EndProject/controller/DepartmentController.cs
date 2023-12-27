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
    }
}