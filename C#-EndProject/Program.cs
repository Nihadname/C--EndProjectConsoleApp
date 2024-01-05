// See https://aka.ms/new-console-template for more information
using C__EndProject.controller;
using C__EndProject.Helpers;
using System.Media;
using static C__EndProject.Helpers.MenusForDepartments;
using static C__EndProject.Helpers.MenusForEmployess;


Console.WriteLine("Hello, World!");
EmployeeController employeeController = new EmployeeController();
DepartmentController departmentController = new DepartmentController();
//MenusForEmployess menusForEmployess = new MenusForEmployess();
helperForColor.changeTextColor(ConsoleColor.Blue, @"
 
 █     █░▓█████  ██▓     ▄████▄   ▒█████   ███▄ ▄███▓▓█████    ▄▄▄█████▓ ▒█████      ▒█████   █    ██  ██▀███      ▄▄▄       ██▓███   ██▓███  
▓█░ █ ░█░▓█   ▀ ▓██▒    ▒██▀ ▀█  ▒██▒  ██▒▓██▒▀█▀ ██▒▓█   ▀    ▓  ██▒ ▓▒▒██▒  ██▒   ▒██▒  ██▒ ██  ▓██▒▓██ ▒ ██▒   ▒████▄    ▓██░  ██▒▓██░  ██▒
▒█░ █ ░█ ▒███   ▒██░    ▒▓█    ▄ ▒██░  ██▒▓██    ▓██░▒███      ▒ ▓██░ ▒░▒██░  ██▒   ▒██░  ██▒▓██  ▒██░▓██ ░▄█ ▒   ▒██  ▀█▄  ▓██░ ██▓▒▓██░ ██▓▒
░█░ █ ░█ ▒▓█  ▄ ▒██░    ▒▓▓▄ ▄██▒▒██   ██░▒██    ▒██ ▒▓█  ▄    ░ ▓██▓ ░ ▒██   ██░   ▒██   ██░▓▓█  ░██░▒██▀▀█▄     ░██▄▄▄▄██ ▒██▄█▓▒ ▒▒██▄█▓▒ ▒
░░██▒██▓ ░▒████▒░██████▒▒ ▓███▀ ░░ ████▓▒░▒██▒   ░██▒░▒████▒     ▒██▒ ░ ░ ████▓▒░   ░ ████▓▒░▒▒█████▓ ░██▓ ▒██▒    ▓█   ▓██▒▒██▒ ░  ░▒██▒ ░  ░
░ ▓░▒ ▒  ░░ ▒░ ░░ ▒░▓  ░░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒░   ░  ░░░ ▒░ ░     ▒ ░░   ░ ▒░▒░▒░    ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒ ░ ▒▓ ░▒▓░    ▒▒   ▓▒█░▒▓▒░ ░  ░▒▓▒░ ░  ░
  ▒ ░ ░   ░ ░  ░░ ░ ▒  ░  ░  ▒     ░ ▒ ▒░ ░  ░      ░ ░ ░  ░       ░      ░ ▒ ▒░      ░ ▒ ▒░ ░░▒░ ░ ░   ░▒ ░ ▒░     ▒   ▒▒ ░░▒ ░     ░▒ ░     
  ░   ░     ░     ░ ░   ░        ░ ░ ░ ▒  ░      ░      ░        ░      ░ ░ ░ ▒     ░ ░ ░ ▒   ░░░ ░ ░   ░░   ░      ░   ▒   ░░       ░░       
    ░       ░  ░    ░  ░░ ░          ░ ░         ░      ░  ░                ░ ░         ░ ░     ░        ░              ░  ░                  
                        ░                                                                                                                     

");

 helperForColor.changeTextColor(ConsoleColor.Blue, "you have some options to choose among them");
 helperForColor.changeTextColor(ConsoleColor.Blue, "options will appear in the bottom part");   
  


if (OperatingSystem.IsWindows())
{
    SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\nihad\source\repos\C#-EndProject\C#-EndProject\music2.wav");
    soundPlayer.PlaySync();
    soundPlayer.Stop();

}
//if (OperatingSystem.IsWindows())
//{
  //  SoundPlayer soundPlayer1 = new SoundPlayer(@"C:\Users\nihad\source\repos\C#-EndProject\C#-EndProject\Brian Eno - An Ending (Ascent) (Remastered 2019).wav");
    //soundPlayer1.PlaySync();
  //  soundPlayer1.PlayLooping();
//}

while (true)
{
    helperForColor.changeTextColor(ConsoleColor.Red,
   "1. Create Employee\n" +
    "2. Get All Employees\n" +
    "3. Get All With Names\n" +
    "4. Get By ID\n" +
    "5. Get All With Age\n" +
    "6. Get All With Department ID\n" +
    "7. Get All With Department Name\n" +
    "8. Get All Employees Count\n" +
    "9. Get Employees Count By ID\n" +
    "10. Delete Employee\n" +
    "11. Update Employee\n" +
    "12. General Revenue Controller\n" +
    "13. Get All With Salary\n" +
    "14. Create Department\n" +
    "15. Get All Departments\n" +
    "16. Get Department With Name\n" +
    "17. Get Department By ID\n" +
    "18. Get Department By Capacity\n" +
    "19. Delete Department\n" +
    "20. Update Department\n" +
    "0. Left Menu"
);
    

    string menu = Console.ReadLine();
    bool result = int.TryParse(menu, out int intMenu);
    if (result && intMenu > 0 && intMenu < 21)
    {
        switch(intMenu)
        {
            case (int)MenusForEmployess.createEmployee:
                employeeController.CreateEmployee();
                break;
            case (int)MenusForEmployess.getAllEmployee:
                if (OperatingSystem.IsWindows())
                {
                    SoundPlayer soundPlayer1 = new SoundPlayer(@"C:\Users\nihad\source\repos\C#-EndProject\C#-EndProject\here are all the employee 1.wav");
                    soundPlayer1.PlaySync();
                    soundPlayer1.Stop();

                }
                employeeController.GetAllEmployee();
                break;
            case (int)MenusForEmployess.GetAllWithNames:
                employeeController.GetAllWithNames();
                break;
            case (int)MenusForEmployess.getById:
                employeeController.getById();
                break;
                case (int)MenusForEmployess.GetAllWithAge: 
                employeeController.GetAllWithAge();  
                break;
                case (int)MenusForEmployess.GetAllWithDepartmentId: 
                employeeController.GetAllWithDepartmentId();
                break;
            case (int)MenusForEmployess.GetAllWithDepartmentName:
                employeeController.GetAllWithDepartmentName();
                break;
            case (int)MenusForEmployess.GetAllEmployeesCount:
                employeeController.GetAllEmployeesCount();
                break;
            case (int)MenusForEmployess.GetAllWithEmployessCountById:
                employeeController.GetAllEmployeesCountById();
                break;
            case (int)MenusForEmployess.deleteEmployee:
                employeeController.DeleteEmployee();
                break;
            case (int)MenusForEmployess.UpdateEmployee:
                employeeController.UpdateEmployee();
                break;
            case (int)MenusForEmployess.GeneralRevenueController:
                employeeController.GeneralRevenueController();
                break;
            case (int)MenusForEmployess.getAllWithSalary:
                employeeController.getAllWithSalary();
                break;
            case (int)MenusForDepartments.createdepartment:
                departmentController.createDepartment();
                break;
            case (int)MenusForDepartments.getAllDepartments:
                if (OperatingSystem.IsWindows())
                {
                    SoundPlayer sound = new SoundPlayer(@"C:\Users\nihad\source\repos\C#-EndProject\C#-EndProject\here are all the Departme 1.wav");
                    sound.PlaySync();
                    sound.Stop();

                }
                departmentController.GetAllDepartment();
                break;
            case (int)MenusForDepartments.GetWithName:
                departmentController.GetWithName();
                break;
            case (int)MenusForDepartments.GetDepartmentById:
                departmentController.GetDepartmentById();
                break;
            case (int)MenusForDepartments.GetDepartmentByCapacity:
                departmentController.GetDepartmentByCapacity();
                break;
            case (int)MenusForDepartments.deleteDparments:
                departmentController.DeleteDepartment();
                break;
                case (int)MenusForDepartments.UptadeDepartment:
                departmentController.UptadeDepartment();
                break;
           
        }
    }
    else if (intMenu == 0)
    {
        helperForColor.changeTextColor(ConsoleColor.Red, "you left the menu");
        break;

    }
    else
    {
        helperForColor.changeTextColor(ConsoleColor.Red, "duzgun eded daxil edin");

        //goto EnterMenu;
    }


}


