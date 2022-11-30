﻿using System.ComponentModel.DataAnnotations;

namespace CodeFirstApproach.DAL
{
    public class Department
    {       
        
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
