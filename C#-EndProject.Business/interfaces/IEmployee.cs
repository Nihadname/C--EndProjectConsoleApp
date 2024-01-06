using C__EndProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__EndProject.Business.interfaces
{
    public interface IEmployee
    {
        Employee  Create(Employee employee,string DepartmentName);
        Employee Update(int id,Employee employee,string groupName);
        Employee get(int id);
        Employee delete(int id);
        List<Employee> GetAll();
        List<Employee> GetAll(int age);
        List<Employee> GetAllWithDepartmentId(byte departmentId);
        List<Employee> GetAll(string departmentName);
        List<Employee> GetAllWithDepartmentName(string departmentName);
        int GetCount();
        int GetCount(byte departmentId);
        

        void HireEmployeeAndUpdateRevenue(Employee employee);
        List<Employee> getAllWithSalary(int num);

    }
}
