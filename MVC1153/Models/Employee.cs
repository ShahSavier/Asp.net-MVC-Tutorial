using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC1153.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public string Campus { get; set; }
        public double Salary { get; set; }
        public double Deduction { get; set; }
        public double NetSalary { get; set; }
    }
}
