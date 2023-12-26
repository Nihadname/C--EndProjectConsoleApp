// See https://aka.ms/new-console-template for more information
using C__EndProject.controller;
using C__EndProject.Helpers;
using static C__EndProject.Helpers.MenusForEmployess;

Console.WriteLine("Hello, World!");
EmployeeController employeeController = new EmployeeController();
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
    helperForColor.changeTextColor(ConsoleColor.Red, "1.createEmployee"+ "2.getAllEmployees");
    string menu = Console.ReadLine();
    bool result = int.TryParse(menu, out int intMenu);
    if (result && intMenu > 0 && intMenu < 12)
    {
        switch(intMenu)
        {
            case (int)MenusForEmployee.createEmployees:
                employeeController.CreateEmployee();
                break;
            case (int)MenusForEmployee.getAllEmployees:
                employeeController.getAllEmployee();
                break;
        }
    }


}