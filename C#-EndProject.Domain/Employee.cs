using C__EndProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__EndProject.Domain
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public int Salary { get; set; }
        public Department department { get; set; }
        public DateTime CreatedTime { get; set; }
        public override string ToString()
        {
            return $" ad {Name}  soyad:{SurName} id: {Id} salary{Salary}   createdTime {CreatedTime}";
        }
    }
}
