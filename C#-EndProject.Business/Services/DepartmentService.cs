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
            if (Creating )
            {
            
                
                    department.Id = Count++;

                    return department;
                
               }
            else
            {
                return null;
            }

        }

        public Department Delete(int id)
        {
            var ExistedDepartment = _Deparmentrepository.Get(s => s.Id == id);
            if (ExistedDepartment is null) return null;
            if (_Deparmentrepository.Delete(ExistedDepartment)){
                return ExistedDepartment;
            }
            else
            {
                return null;
            }

        }

        public Department Get(int id)
        {
            return _Deparmentrepository.Get(s=>s.Id==id);
        }

        public List<Department> GetAll()
        {
            return _Deparmentrepository.GetAll();
        }

        public Department Get(string Name)
        {
            return _Deparmentrepository.Get(s=>s.Name.Equals(Name,StringComparison.OrdinalIgnoreCase));
        }

        public List<Department> GetAll(int maxsize)
        {
          return _Deparmentrepository.GetAll(s=>s.Capacity==maxsize);
        }

        public Department Uptade(int id, Department department)
        {
            var ExistedDepartment=_Deparmentrepository.Get(s=>s.Id==id);
            if (ExistedDepartment is null) return null;
            var ExistedDepartmentWithItsName=_Deparmentrepository.Get(g=>g.Name.Equals(department.Name,StringComparison.OrdinalIgnoreCase) &&g.Id!=ExistedDepartment.Id);
            if (ExistedDepartmentWithItsName is not null) return null;
            if (!string.IsNullOrEmpty(department.Name))
            {
                ExistedDepartment.Name = department.Name;

            }
            //  ExistedDepartment.Name = department.Name;   
ExistedDepartment.Capacity = department.Capacity;
            if (_Deparmentrepository.Update(department)) return ExistedDepartment;
            return null;
        }

        
    }
}
