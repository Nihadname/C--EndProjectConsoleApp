﻿using C__EndProject.DataContext.interfaces;
using C__EndProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__EndProject.DataContext.repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public bool Create(Employee entity)
        {
            try
            {
                DbContext.employees.Add(entity);
                return true;
            }catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(Employee entity)
        {
            try
            {
                DbContext.employees.Remove(entity);
                return true;
            }catch(Exception)
            {
                throw;
            }
        }

        public Employee Get(Predicate<Employee> filter)
        {
            return DbContext.employees.Find(filter);
        }

        public List<Employee> GetAll(Predicate<Employee> filter = null)
        {
            return filter is null?DbContext.employees:DbContext.employees.FindAll(filter);  
        }

        public bool Update(Employee entity)
        {
            try {
                var ExistedEmployee = Get(s => s.Id == entity.Id);
                ExistedEmployee = entity;
                return true;
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
