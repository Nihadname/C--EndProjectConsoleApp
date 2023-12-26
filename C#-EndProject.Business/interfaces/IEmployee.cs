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
        Employee  Create(Employee employee);
        Employee Update(int id,Employee employee);
        Employee get(int id);
        Employee delete(int id);
        List<Employee> GetAll(int age);
        List<Employee> GetAll(byte departmentId);


    }
}
