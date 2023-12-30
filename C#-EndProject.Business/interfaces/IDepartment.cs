using C__EndProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__EndProject.Business.interfaces
{
    public interface IDepartment
    {
        Department Create(Department department);
        Department Uptade(int id,Department department);
        Department Delete(int id);
            Department Get(int id);
      List<Department> GetAll();
        Department Get(string Name);
        List<Department> GetAll(int maxsize);

    }
}
