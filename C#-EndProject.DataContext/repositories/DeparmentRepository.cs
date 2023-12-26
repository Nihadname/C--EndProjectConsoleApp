using C__EndProject.DataContext.interfaces;
using C__EndProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__EndProject.DataContext.repositories
{
    public class DeparmentRepository : IRepository<Department>
    {
        public bool Create(Department entity)
        {
            try
            {
                DbContext.departments.Add(entity);
                return true;
            }catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(Department entity)
        {
            try
            {
                DbContext.departments.Remove(entity);
                return true;
            }catch (Exception)
            {
                throw;
            }
            
        }

        public Department Get(Predicate<Department> filter)
        {
            return DbContext.departments.Find(filter);
        }

        public List<Department> GetAll(Predicate<Department> filter = null)
        {
            return filter is null ? DbContext.departments : DbContext.departments.FindAll(filter);
        }

        public bool Update(Department entity)
        {
            try
            {
                var ExistedDeparment = Get(s => s.Id == entity.Id);
                ExistedDeparment = entity;
                return true;
            }catch(Exception)
            {
                throw;
            }
        }
    }
}
