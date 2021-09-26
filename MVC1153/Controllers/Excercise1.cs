using Microsoft.AspNetCore.Mvc;
using MVC1153.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC1153.Controllers
{
    public class Excercise1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NumberList()
        {
            IList<int> listNumber = new List<int>() { 10, 20, 30, 40 };
            ViewBag.ListNumbers = listNumber;
            return View();
        }
        public IActionResult AddNumberList()
        {
            IList<int> listNumbers = new List<int>();
            listNumbers.Add(10);
            listNumbers.Add(20);
            listNumbers.Add(30);
            listNumbers.Add(40);
            listNumbers.Add(50);
            ViewBag.ListNumbers = listNumbers;
            return View();
        }
        public IActionResult PetList()
        {
            IList<string> listPets = new List<string>()
            {
                "Cat", "Dog", "Rabbit", "Hamster"
            };
            listPets.Add("Gecko");
            listPets.Add("Turttle");
            ViewBag.ListPets = listPets;
            return View();
        }
        public IActionResult RemoveNumberList()
        {
            IList<int> listNumbers = new List<int>()
            {
                1, 2, 3, 4, 5, 1, 2
            };
            listNumbers.Remove(2);
            ViewBag.ListNumbers = listNumbers;
            return View();
        }
        public IActionResult InfoPetList()
        {
            IList<string> listPets = new List<string>()
            {
                "Cat", "Dog", "Rabbit", "Hamster"
            };
            int count = listPets.Count;
            bool contains = listPets.Contains("Rabbit");
            int indexOf = listPets.IndexOf("Rabbit");

            ViewBag.Listpets = listPets;
            ViewBag.Count = count;
            ViewBag.Contains = contains;
            ViewBag.IndexOf = indexOf;
            return View();
        }

        public IActionResult EmployeeList()
        {
            IList<Employee> listEmployees = new List<Employee>()
            {
            new Employee() { EmpId = 1, Name = "Hang Tuah", Gender = "M",
                Position = "Lecturer", StartDate = new DateTime(2010, 7, 1),
                Campus = "MIIT", Salary = 4631},
            new Employee() { EmpId = 2, Name = "Hang Jebat", Gender = "M",
                Position = "Executive", StartDate = new DateTime(2010, 4, 15),
                Campus = "BMI", Salary = 3850},
            new Employee() { EmpId = 6, Name = "Hang Li Po", Gender = "F",
                Position = "Senior Lecturer", StartDate = new DateTime(2014, 5, 15),
                Campus = "MIIT", Salary = 6631},
            new Employee() { EmpId = 8, Name = "Tun Fatimah", Gender = "F",
                Position = "Clerk", StartDate = new DateTime(2008, 08, 1),
                Campus = "BMI", Salary = 2150}
            };
            // Sort by name, date and Sallary
            ViewBag.OrderName = listEmployees.OrderBy(x => x.Name);
            ViewBag.OrderStartDate = listEmployees.OrderBy(x => x.StartDate);
            ViewBag.OrderDescSalary = listEmployees.OrderByDescending(x => x.Salary);

            // Sort by Campus & Name employee
            ViewBag.OrderCampusName = listEmployees.OrderBy(x => x.Campus).ThenBy(x => x.Name);

            return View(listEmployees);
        }
        public IActionResult EmployeeListRestriction()
        {
            IList<Employee> listEmployees = new List<Employee>()
            {
            new Employee() { EmpId = 1, Name = "Hang Tuah", Gender = "M",
                Position = "Lecturer", StartDate = new DateTime(2010, 7, 1),
                Campus = "MIIT", Salary = 4631},
            new Employee() { EmpId = 2, Name = "Hang Jebat", Gender = "M",
                Position = "Executive", StartDate = new DateTime(2010, 4, 15),
                Campus = "BMI", Salary = 3850},
            new Employee() { EmpId = 3, Name = "Hang Lekir", Gender = "M",
                Position = "Assoc. Professor", StartDate = new DateTime(2015, 6, 1),
                Campus = "MFI", Salary = 10020},
            new Employee() { EmpId = 4, Name = "Hang Lekiu", Gender = "M",
                Position = "Technician", StartDate = new DateTime(2015, 3, 15),
                Campus = "BMI", Salary = 2050},
            new Employee() { EmpId = 5, Name = "Hang Kasturi", Gender = "M",
                Position = "Professor", StartDate = new DateTime(2014, 7, 1),
                Campus = "MIIT", Salary = 16205},
            new Employee() { EmpId = 6, Name = "Hang Li Po", Gender = "F",
                Position = "Senior Lecturer", StartDate = new DateTime(2014, 5, 15),
                Campus = "MIIT", Salary = 6631},
            new Employee() { EmpId = 7, Name = "Hang Nadim", Gender = "M",
                Position = "Manager", StartDate = new DateTime(2012, 10, 1),
                Campus = "MIIT", Salary = 5300},
            new Employee() { EmpId = 8, Name = "Tun Fatimah", Gender = "F",
                Position = "Clerk", StartDate = new DateTime(2008, 08, 1),
                Campus = "BMI", Salary = 2150},
            new Employee() { EmpId = 9, Name = "Dang Anum", Gender = "F",
                Position = "Executive", StartDate = new DateTime(2008, 08, 1),
                Campus = "MFI", Salary = 3300},
            new Employee() { EmpId = 10, Name = "Tun Perak", Gender = "M",
                Position = "Professor", StartDate = new DateTime(2008, 08, 1),
                Campus = "MIIT", Salary = 15300}
            };
            // Action method for more data
            ViewBag.Female = listEmployees.Where(x => x.Gender == "F");
            ViewBag.MIIT = listEmployees.Where(x => x.Campus == "MIIT");
            ViewBag.HighSalary = listEmployees.Where(x => x.Salary >= 5000);
            ViewBag.Senior = listEmployees.Where(x => x.StartDate < new DateTime(2011, 01, 01));
            //Multiple Condition
            ViewBag.SeniorMale = listEmployees.Where(x => x.StartDate < new DateTime(2011, 01, 01)
            && x.Gender == "M");
            ViewBag.MIITMFI = listEmployees.Where(x => x.Campus == "MIIT" || x.Campus == "MFI")
            .OrderBy(x => x.Campus).ThenBy(x => x.Name);
            return View(listEmployees);
        }

        public IActionResult EmployeeListAdd()
        {
            IList<Employee> listEmployees = new List<Employee>()
            {
                new Employee
                {
                    EmpId = 1, Name = "Hang Tuah", Gender ="M",
                    Position = "Lecturer", StartDate = new DateTime (2010, 7, 1),
                    Campus ="MIIT", Salary = 4631
                },
                new Employee
                {
                    EmpId = 2, Name = "Hang Jebat", Gender ="M",
                    Position = "Executive", StartDate = new DateTime (2010, 4, 15),
                    Campus ="BMI", Salary = 3850
                },
                new Employee
                {
                    EmpId = 6, Name = "Hang Li Po", Gender ="F",
                    Position = "Senior Lecturer", StartDate = new DateTime (2014, 5, 15),
                    Campus ="MIIT", Salary = 6631
                }
            };
            listEmployees.Add(new Employee
            {
                EmpId = 10,
                Name = "Tun Razak",
                Gender = "M",
                Position = "Professor",
                StartDate = new DateTime(2008, 8, 1),
                Campus = "MIIT",
                Salary = 15300
            });
            return View(listEmployees);
        }
        public IActionResult EmployeeRestAgg()
        {
            IList<Employee> listEmployees = new List<Employee>()
            {
            new Employee() { EmpId = 1, Name = "Hang Tuah", Gender = "M",
                Position = "Lecturer", StartDate = new DateTime(2010, 7, 1),
                Campus = "MIIT", Salary = 4631},
            new Employee() { EmpId = 2, Name = "Hang Jebat", Gender = "M",
                Position = "Executive", StartDate = new DateTime(2010, 4, 15),
                Campus = "BMI", Salary = 3850},
            new Employee() { EmpId = 3, Name = "Hang Lekir", Gender = "M",
                Position = "Assoc. Professor", StartDate = new DateTime(2015, 6, 1),
                Campus = "MFI", Salary = 10020},
            new Employee() { EmpId = 4, Name = "Hang Lekiu", Gender = "M",
                Position = "Technician", StartDate = new DateTime(2015, 3, 15),
                Campus = "BMI", Salary = 2050},
            new Employee() { EmpId = 5, Name = "Hang Kasturi", Gender = "M",
                Position = "Professor", StartDate = new DateTime(2014, 7, 1),
                Campus = "MIIT", Salary = 16205},
            new Employee() { EmpId = 6, Name = "Hang Li Po", Gender = "F",
                Position = "Senior Lecturer", StartDate = new DateTime(2014, 5, 15),
                Campus = "MIIT", Salary = 6631},
            new Employee() { EmpId = 7, Name = "Hang Nadim", Gender = "M",
                Position = "Manager", StartDate = new DateTime(2012, 10, 1),
                Campus = "MIIT", Salary = 5300},
            new Employee() { EmpId = 8, Name = "Tun Fatimah", Gender = "F",
                Position = "Clerk", StartDate = new DateTime(2008, 08, 1),
                Campus = "BMI", Salary = 2150},
            new Employee() { EmpId = 9, Name = "Dang Anum", Gender = "F",
                Position = "Executive", StartDate = new DateTime(2008, 08, 1),
                Campus = "MFI", Salary = 3300},
            new Employee() { EmpId = 10, Name = "Tun Perak", Gender = "M",
                Position = "Professor", StartDate = new DateTime(2008, 08, 1),
                Campus = "MIIT", Salary = 15300}
            };
            //Count Employee
            ViewBag.countAll = listEmployees.Count();
            ViewBag.countMale = listEmployees.Where(x => x.Gender == "M").Count();
            ViewBag.countFemale = listEmployees.Where(x => x.Gender == "F").Count();
            ViewBag.AverageSalary = listEmployees.Average(x => x.Salary);
            ViewBag.AverageSalaryMale = listEmployees.Where(x => x.Gender == "M").Average(x => x.Salary);
            ViewBag.AverageSalaryFemale = listEmployees.Where(x => x.Gender == "F").Average(x => x.Salary);
            return View(listEmployees);
        }

        public IActionResult findElement()
        {
            IList<Employee> listEmployees = new List<Employee>()
            {
            new Employee() { EmpId = 1, Name = "Hang Tuah", Gender = "M",
                Position = "Lecturer", StartDate = new DateTime(2010, 7, 1),
                Campus = "MIIT", Salary = 4631},
            new Employee() { EmpId = 2, Name = "Hang Jebat", Gender = "M",
                Position = "Executive", StartDate = new DateTime(2010, 4, 15),
                Campus = "BMI", Salary = 3850},
            new Employee() { EmpId = 3, Name = "Hang Lekir", Gender = "M",
                Position = "Assoc. Professor", StartDate = new DateTime(2015, 6, 1),
                Campus = "MFI", Salary = 10020},
            new Employee() { EmpId = 4, Name = "Hang Lekiu", Gender = "M",
                Position = "Technician", StartDate = new DateTime(2015, 3, 15),
                Campus = "BMI", Salary = 2050},
            new Employee() { EmpId = 5, Name = "Hang Kasturi", Gender = "M",
                Position = "Professor", StartDate = new DateTime(2014, 7, 1),
                Campus = "MIIT", Salary = 16205},
            new Employee() { EmpId = 6, Name = "Hang Li Po", Gender = "F",
                Position = "Senior Lecturer", StartDate = new DateTime(2014, 5, 15),
                Campus = "MIIT", Salary = 6631},
            new Employee() { EmpId = 7, Name = "Hang Nadim", Gender = "M",
                Position = "Manager", StartDate = new DateTime(2012, 10, 1),
                Campus = "MIIT", Salary = 5300},
            new Employee() { EmpId = 8, Name = "Tun Fatimah", Gender = "F",
                Position = "Clerk", StartDate = new DateTime(2008, 08, 1),
                Campus = "BMI", Salary = 2150},
            new Employee() { EmpId = 9, Name = "Dang Anum", Gender = "F",
                Position = "Executive", StartDate = new DateTime(2008, 08, 1),
                Campus = "MFI", Salary = 3300},
            new Employee() { EmpId = 10, Name = "Tun Perak", Gender = "M",
                Position = "Professor", StartDate = new DateTime(2008, 08, 1),
                Campus = "MIIT", Salary = 15300}
            };

            //Search by Id
            var result = listEmployees.First(x => x.EmpId == 5);
            return View(result);
        }
        public IActionResult SelectSubSet()
        {
            IList<Employee> listEmployees = new List<Employee>()
            {
            new Employee() { EmpId = 1, Name = "Hang Tuah", Gender = "M",
                Position = "Lecturer", StartDate = new DateTime(2010, 7, 1),
                Campus = "MIIT", Salary = 4631},
            new Employee() { EmpId = 2, Name = "Hang Jebat", Gender = "M",
                Position = "Executive", StartDate = new DateTime(2010, 4, 15),
                Campus = "BMI", Salary = 3850},
            new Employee() { EmpId = 3, Name = "Hang Lekir", Gender = "M",
                Position = "Assoc. Professor", StartDate = new DateTime(2015, 6, 1),
                Campus = "MFI", Salary = 10020},
            new Employee() { EmpId = 4, Name = "Hang Lekiu", Gender = "M",
                Position = "Technician", StartDate = new DateTime(2015, 3, 15),
                Campus = "BMI", Salary = 2050},
            new Employee() { EmpId = 5, Name = "Hang Kasturi", Gender = "M",
                Position = "Professor", StartDate = new DateTime(2014, 7, 1),
                Campus = "MIIT", Salary = 16205},
            new Employee() { EmpId = 6, Name = "Hang Li Po", Gender = "F",
                Position = "Senior Lecturer", StartDate = new DateTime(2014, 5, 15),
                Campus = "MIIT", Salary = 6631},
            new Employee() { EmpId = 7, Name = "Hang Nadim", Gender = "M",
                Position = "Manager", StartDate = new DateTime(2012, 10, 1),
                Campus = "MIIT", Salary = 5300},
            new Employee() { EmpId = 8, Name = "Tun Fatimah", Gender = "F",
                Position = "Clerk", StartDate = new DateTime(2008, 08, 1),
                Campus = "BMI", Salary = 2150},
            new Employee() { EmpId = 9, Name = "Dang Anum", Gender = "F",
                Position = "Executive", StartDate = new DateTime(2008, 08, 1),
                Campus = "MFI", Salary = 3300},
            new Employee() { EmpId = 10, Name = "Tun Perak", Gender = "M",
                Position = "Professor", StartDate = new DateTime(2008, 08, 1),
                Campus = "MIIT", Salary = 15300}
            };
            var result = listEmployees.Select(x => new Employee() { EmpId = x.EmpId, Name = x.Name, Position = x.Position });
            return View(result);
        }
        public IActionResult SelectNetSalary()
        {
            IList<Employee> listEmployees = new List<Employee>()
            {
            new Employee() { EmpId = 1, Name = "Hang Tuah", Gender = "M",
                Position = "Lecturer", StartDate = new DateTime(2010, 7, 1),
                Campus = "MIIT", Salary = 4631},
            new Employee() { EmpId = 2, Name = "Hang Jebat", Gender = "M",
                Position = "Executive", StartDate = new DateTime(2010, 4, 15),
                Campus = "BMI", Salary = 3850},
            new Employee() { EmpId = 3, Name = "Hang Lekir", Gender = "M",
                Position = "Assoc. Professor", StartDate = new DateTime(2015, 6, 1),
                Campus = "MFI", Salary = 10020},
            new Employee() { EmpId = 4, Name = "Hang Lekiu", Gender = "M",
                Position = "Technician", StartDate = new DateTime(2015, 3, 15),
                Campus = "BMI", Salary = 2050},
            new Employee() { EmpId = 5, Name = "Hang Kasturi", Gender = "M",
                Position = "Professor", StartDate = new DateTime(2014, 7, 1),
                Campus = "MIIT", Salary = 16205},
            new Employee() { EmpId = 6, Name = "Hang Li Po", Gender = "F",
                Position = "Senior Lecturer", StartDate = new DateTime(2014, 5, 15),
                Campus = "MIIT", Salary = 6631},
            new Employee() { EmpId = 7, Name = "Hang Nadim", Gender = "M",
                Position = "Manager", StartDate = new DateTime(2012, 10, 1),
                Campus = "MIIT", Salary = 5300},
            new Employee() { EmpId = 8, Name = "Tun Fatimah", Gender = "F",
                Position = "Clerk", StartDate = new DateTime(2008, 08, 1),
                Campus = "BMI", Salary = 2150},
            new Employee() { EmpId = 9, Name = "Dang Anum", Gender = "F",
                Position = "Executive", StartDate = new DateTime(2008, 08, 1),
                Campus = "MFI", Salary = 3300},
            new Employee() { EmpId = 10, Name = "Tun Perak", Gender = "M",
                Position = "Professor", StartDate = new DateTime(2008, 08, 1),
                Campus = "MIIT", Salary = 15300}
            };
            var result1 = listEmployees.Select(x => new Employee()
            {
                EmpId = x.EmpId,
                Name = x.Name,
                Position = x.Position,
                Salary = x.Salary,
                Deduction = x.Salary *0.09,
                NetSalary = x.Salary -(x.Salary * 0.09)
            });
            var result2 = listEmployees.Select(x => new Employee()
            {
                EmpId = x.EmpId,
                Name = x.Name,
                Position = x.Position,
                Salary = x.Salary,
                Deduction = x.Salary * 0.09,
                NetSalary = x.Salary - (x.Salary * 0.09)
            }).Where (x => x.Deduction >= 1000).OrderBy(x => x.Name);
            return View(result2);
        }
    }
}
