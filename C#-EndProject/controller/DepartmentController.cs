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
                File.WriteAllText(filePath, MessagesForCases.MessagesForEmptyCases);
                helperForColor.changeTextColor(ConsoleColor.Red, MessagesForCases.MessagesForEmptyCases);
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
                if(GettingById != null)
            {
                Console.WriteLine(GettingById);

            }
            else
            {
                helperForColor.changeTextColor(ConsoleColor.Red, MessagesForCases.MessageForCasesWhenIdDoesntMatch);


            }

        }
        public void GetDepartmentByCapacity()
        {
            helperForColor.changeTextColor(ConsoleColor.Green, "reqem daxil edin");
            string number = Console.ReadLine();
            bool result = int.TryParse(number, out int GroupCount);
            var GettingById = departmentService.GetAll(GroupCount);
            foreach( var item in GettingById)
            {
                Console.WriteLine(item);
            }
        }
        public void DeleteDepartment()
        {
            helperForColor.changeTextColor(ConsoleColor.Red, "enter Id");
            int id = int.Parse(Console.ReadLine());
            var result = departmentService.Delete(id);
            if(result is null)
            {
                helperForColor.changeTextColor(ConsoleColor.Red, "something went wrong");

            }
            else
            {
                helperForColor.changeTextColor(ConsoleColor.Green, "deleted");

            }
        }
        public void UptadeDepartment()
        {
            helperForColor.changeTextColor(ConsoleColor.Red, "enter Id");
            int id = int.Parse(Console.ReadLine());
            helperForColor.changeTextColor(ConsoleColor.Red, "enter new department Name");
            string name = Console.ReadLine();
            
            helperForColor.changeTextColor(ConsoleColor.Green, "enter new capacity ");
            string capacity = Console.ReadLine();
            bool result=int.TryParse(capacity, out int DepartmentCount);
            Department department=new Department();
            
            department.Name = name;
            department.Capacity = DepartmentCount;
            var UpdatedDepartment = departmentService.Uptade(id, department);
            if (result){
                if (UpdatedDepartment is not null)
                {
                    helperForColor.changeTextColor(ConsoleColor.Red, $"{department.Name}  succesfully updated");
                }
                else
                {
                    helperForColor.changeTextColor(ConsoleColor.Green, "something went wrong");

                }
            }

        }
    }
}