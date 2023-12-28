using C__EndProject.Business.interfaces;
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
            employee.department = ExistedDepartmenName;
            employee.Id=Counter++;
            bool CreatingResult=employeeRepository.Create(employee);
            if (!CreatingResult) return null;
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
         return  employeeRepository.Get(s=>s.Id==id);
        }

        public List<Employee> GetAll(int age)
        {
            return employeeRepository.GetAll(s => s.age == age);

        }

        public List<Employee> GetAllWithDepartmentId(byte departmentId)
        {
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

        public Employee Update(int id, Employee employee, string DepartmentName)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
       return employeeRepository.GetAll();
        }

        public int GetCount()
        {
          return GetAll().Count;
        }
    }
}
