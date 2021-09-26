using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC1153.AssignedValues;

namespace MVC1153.Controllers
{
    public class ArrayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IntegerArray()
        {
            // Using LINQ
            int[] numbers = { 6, 3, 1, 2, 5, 4 };
            ViewBag.Numbers = numbers;
            ViewBag.CountNumber = numbers.Count(); //count number array
            ViewBag.MaxNumber = numbers.Max();
            ViewBag.MinNumber = numbers.Min();
            ViewBag.SumNumbers = numbers.Sum();
            ViewBag.AverageNumbers = numbers.Average();
            return View();
        }
        public IActionResult StringArray()
        {
            //Sort by ASC or DSC
            string[] pets = { "Turtle", "Hamster", "Rabbit", "Dog", "Cat" };
            ViewBag.Pets = pets;

            ViewBag.Results1 = pets.OrderBy(x => x);
            ViewBag.Results2 = pets.OrderByDescending(x => x);
            return View();
        }
        public IActionResult PosLajuRatesArray()
        {
            // 2 dimensional array
            PosLaju posLaju = new PosLaju(); // Access poslaju class
            ViewBag.WeightCategories = posLaju.weightCategories;
            ViewBag.Zones = posLaju.zones;
            ViewBag.rates = posLaju.rates;
            return View();
        }
        //Multiplication Table
        public IActionResult MultiplicationArray()
        {
            int[,] multiplications = new int[13, 13];
            for (int i = 1; i <= 12; i++) //for loop
            {
                for (int j = 1; j <= 12; j++)
                {
                    multiplications[i, j] = i * j;
                }
            }
            ViewBag.Multiplications = multiplications;
            return View();
        }
        public IActionResult Jagged1DimensionalArray()
        {
            //Jagged Array assign in class1.cs
            SoftwareHouse softHouse = new SoftwareHouse();
            ViewBag.Employees = softHouse.employees;
            ViewBag.Skills = softHouse.skills;
            return View();
        }
        public IActionResult Jagged2DimensionalArray()
        {
            //Jagged 2 Dimensional Array assign in class1.cs
            CourseGrade cGrade = new CourseGrade();
            ViewBag.Students = cGrade.students;
            ViewBag.Courses = cGrade.courses;
            return View();
        }
    }
}
