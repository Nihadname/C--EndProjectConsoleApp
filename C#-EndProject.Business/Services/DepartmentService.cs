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
        private readonly EmployeeRepository _EmployeeRepository;
        private static int Count = 1;
        private DateTime currentDate = DateTime.Now;



        public DepartmentService()
        {
            _Deparmentrepository = new DeparmentRepository();
            _EmployeeRepository = new EmployeeRepository();
        }
        public Department Create(Department department)
        {
            var ExistedDeparmentWithName=_Deparmentrepository.Get(g => g.Name.Equals(department.Name, StringComparison.OrdinalIgnoreCase));
            if (ExistedDeparmentWithName is not null) return null;
            if (string.IsNullOrEmpty(department.Name))
            {
                return null;
            }

            if (department.Capacity < 0)
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
        public double GetUpdatedRevenue()
        {
            var departments = _Deparmentrepository.GetAll(); // Assuming this retrieves all departments

            double totalRevenue = 0;

            foreach (var department in departments)
            {
                totalRevenue += department.revenue;
            }

            return totalRevenue;
        }
        public Department Delete(int id)
        {
            var existedDepartment = _Deparmentrepository.Get(s => s.Id == id);
            if (existedDepartment == null) return null;

            var existedDepartmentEmployees = _EmployeeRepository.GetAll(s => s.department.Id == existedDepartment.Id);

            if (existedDepartmentEmployees != null && existedDepartmentEmployees.Any())
            {
                foreach (var employee in existedDepartmentEmployees)
                {
                    _EmployeeRepository.Delete(employee);
                }
            }

            if (_Deparmentrepository.Delete(existedDepartment))
            {
                return existedDepartment;
            }
            else
            {
                return null;
            }
        }

        public Department Get(int id)
        {
            if(_Deparmentrepository.Get(s=>s.Id==id) == null)
            {
                return null;
            }
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
        public void GeneralRevenueController(int num)

        {
            currentDate = currentDate.AddMonths(num);


            Random random = new Random();
            double randomIncrease = random.Next(1000, 5000);
            foreach (var department in _Deparmentrepository.GetAll())
            {
                department.revenue += randomIncrease;
            }
        }


    }
}
