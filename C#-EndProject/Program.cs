// See https://aka.ms/new-console-template for more information
using C__EndProject.controller;
using C__EndProject.Helpers;
using static C__EndProject.Helpers.MenusForDepartments;
using static C__EndProject.Helpers.MenusForEmployess;

Console.WriteLine("Hello, World!");
EmployeeController employeeController = new EmployeeController();
DepartmentController departmentController = new DepartmentController();
//MenusForEmployess menusForEmployess = new MenusForEmployess();
helperForColor.changeTextColor(ConsoleColor.Green, @"
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




while (true)
{
    helperForColor.changeTextColor(ConsoleColor.Red, "1.createEmployee"+ "2.getAllEmployees"+ "3.GetAllWithNames" + "4.getById"+ "5.GetAllWithAge"+ "6.GetAllWithDepartmentId"+ "7.GetAllWithDepartmentName"+ "8.GetAllEmployeesCount" +"9.deleteEmployee" + "10.UpdateEmployee" + "11.CreateDeparmente" +"12.GetAllDepartment"+ "13.GetAllWithName" + "0.left menu");

    string menu = Console.ReadLine();
    bool result = int.TryParse(menu, out int intMenu);
    if (result && intMenu > 0 && intMenu < 19)
    {
        switch(intMenu)
        {
            case (int)MenusForEmployess.createEmployee:
                employeeController.CreateEmployee();
                break;
            case (int)MenusForEmployess.getAllEmployee:
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
            case (int)MenusForEmployess.deleteEmployee:
                employeeController.DeleteEmployee();
                break;
            case (int)MenusForEmployess.UpdateEmployee:
                employeeController.UpdateEmployee();
                break;
            case (int)MenusForDepartments.createdepartment:
                departmentController.createDepartment();
                break;
            case (int)MenusForDepartments.getAllDepartments:
                departmentController.GetAllDepartment();
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