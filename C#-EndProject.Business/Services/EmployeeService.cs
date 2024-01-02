﻿using C__EndProject.Business.interfaces;
using C__EndProject.DataContext;
using C__EndProject.DataContext.repositories;
using C__EndProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace C__EndProject.Business.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly DeparmentRepository deparmentRepository;
        private static int Counter = 1;
        private double revenue = 1000000; // Initial revenue
        private DateTime currentDate = DateTime.Now;
        public double GetUpdatedRevenue()
        {
            return revenue;
        }
        public EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
            deparmentRepository = new DeparmentRepository();
        }
        public Employee Create(Employee employee, string DepartmentName)
        {
         
            var ExistedDepartmenName=deparmentRepository.Get(s=>s.Name.Equals(DepartmentName,StringComparison.OrdinalIgnoreCase));
            if (ExistedDepartmenName == null) return null;
            if (string.IsNullOrEmpty(employee.Name)||string.IsNullOrEmpty(employee.SurName)||string.IsNullOrEmpty(employee.address))
            {
                return null;
            }

            if (GetCount((byte)ExistedDepartmenName.Id) >= ExistedDepartmenName.Capacity)
            {
                return null; 
            }
            employee.department = ExistedDepartmenName;
            employee.Id=Counter++;
            
            bool CreatingResult=employeeRepository.Create(employee);

            if (!CreatingResult) {
                return null;

            }
             
            return employee;
        }

        public Employee delete(int id)
        {
            var ExistedEmployee=employeeRepository.Get(s=>s.Id==id);
            if (ExistedEmployee is  null) return null;
            if (employeeRepository.Delete(ExistedEmployee))
            {
                return ExistedEmployee;
            }
            else
            {
                return null;
            }
        }

        public Employee get(int id)
        {
            if(employeeRepository.Get(s=>s.Id== id) == null){
                return null;
            }
         return  employeeRepository.Get(s=>s.Id==id);
            
        }

        public List<Employee> GetAll(int age)
        {
            return employeeRepository.GetAll(s => s.age == age);

        }

        public List<Employee> GetAllWithDepartmentId(byte departmentId)
        {
            if (employeeRepository.GetAll(s => s.department.Id == departmentId) == null)
            {
                return null;
            }
            return employeeRepository.GetAll(s=>s.department.Id==departmentId);

           
        }

        public List<Employee> GetAllWithDepartmentName(string departmentName)
        {
           return employeeRepository.GetAll(s=>s.department.Name==departmentName);
        }

        public List<Employee> GetAll(string Name)
        {
            return employeeRepository.GetAll(s=>s.Name.Equals(Name,StringComparison.OrdinalIgnoreCase));
        }

        public Employee Update(int id, Employee employee,string groupName)
        {
            var ExistedEmployee=employeeRepository.Get(s=>s.Id == id);
            if (ExistedEmployee is null) return null;
            var ExistedDeparment=deparmentRepository.Get(s=>s.Name == groupName);
            if (ExistedDeparment is null) return null;
            if(!string.IsNullOrEmpty(employee.Name))
            {
                ExistedEmployee.Name = employee.Name;
            }
            if(!string.IsNullOrEmpty(employee.SurName)) { 
            
            ExistedEmployee.SurName= employee.SurName;
            }
            if(!string.IsNullOrEmpty(employee.address))
            {
                ExistedEmployee.address = employee.address;
            }
            employee.department = ExistedDeparment;
                    ExistedEmployee.Salary = employee.Salary;
            if (employeeRepository.Update(ExistedEmployee))
            {
                return ExistedEmployee;
            }
            else
            {
                return null;
            }
        }

        public List<Employee> GetAll()
        {
       return employeeRepository.GetAll();
        }

        public int GetCount()
        {
            return GetAll().Count;

        }
        public int GetCount(byte departmentId)
        {
            return GetAllWithDepartmentId(departmentId).Count;
        }

        public void HireEmployeeAndUpdateRevenue(Employee employee)
        {
            double salary = employee.Salary;
            revenue -= salary * 1.5;
        }

        public void GeneralRevenueController(int num)

        {
            currentDate = currentDate.AddMonths(num);


            Random random = new Random();
            double randomIncrease = random.Next(1000, 5000); // Random monthly increase
            revenue += randomIncrease;
        }


        public List<Employee> getAllWithSalary(int num)
        {
            return employeeRepository.GetAll(s => s.Salary == num);
        }
    }
}
