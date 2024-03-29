﻿using C__EndProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__EndProject.Domain
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public  double revenue = 1000000;
        public DateTime CreatedTime { get; set; }
        public Department()
        {
            CreatedTime = DateTime.Now;
        }
        public override string ToString()
        {
            return $"Name: {Name} capacity: {Capacity} createdDate {CreatedTime}";
        }
    }
}
