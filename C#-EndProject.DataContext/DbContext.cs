using C__EndProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__EndProject.DataContext
{
    public  static class DbContext
    {
        public static List<Employee> employees {  get; set; }
        public static List<Department> departments { get; set; }
         static DbContext()
        {
           employees = new List<Employee>();
            departments = new List<Department>();
        }
    }
}
