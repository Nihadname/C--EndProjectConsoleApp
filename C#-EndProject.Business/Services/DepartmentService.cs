using C__EndProject.Business.interfaces;
using C__EndProject.DataContext.repositories;
using C__EndProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__EndProject.Business.Services
{
    public class DepartmentService : IDepartment
    {
        private readonly DeparmentRepository _Deparmentrepository;
        private static int Count = 1;

        public DepartmentService()
        {
            _Deparmentrepository = new DeparmentRepository();
        }
        public Department Create(Department department)
        {
            var ExistedDeparmentWithName=_Deparmentrepository.Get(g => g.Name.Equals(department.Name, StringComparison.OrdinalIgnoreCase));
            if (ExistedDeparmentWithName is not null) return null;
            if (string.IsNullOrEmpty(department.Name))
            {
                return null;
            }
            bool Creating = _Deparmentrepository.Create(department);
            department.Id=Count++;
            if (Creating)
            {
                
                return department;
               
            }
            else
            {
                return null;
            }

        }

        public Department Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Department Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll()
        {
            return _Deparmentrepository.GetAll();
        }

        public List<Department> GetAll(string Name)
        {
            return _Deparmentrepository.GetAll(s=>s.Name.Equals(Name,StringComparison.OrdinalIgnoreCase));
        }

        public List<Department> GetAll(int maxsize)
        {
            throw new NotImplementedException();
        }

        public Department Uptade(int id, Department department)
        {
            throw new NotImplementedException();
        }
    }
}
