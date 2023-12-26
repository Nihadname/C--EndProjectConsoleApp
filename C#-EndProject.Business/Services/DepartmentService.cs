﻿using C__EndProject.Business.interfaces;
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

        public DepartmentService()
        {
            _Deparmentrepository = new DeparmentRepository();
        }
        public Department Create(Department department)
        {
            var ExistedDeparment=_Deparmentrepository.Get(s=>s.Id == department.Id);
            if (ExistedDeparment is not null) return null;
            bool Creating = _Deparmentrepository.Create(department);
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
            throw new NotImplementedException();
        }

        public List<Department> GetAll(string Name)
        {
            throw new NotImplementedException();
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