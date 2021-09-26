using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC1153.Models;

namespace MVC1153.Controllers
{
    public class LearnController : Controller
    {
        public IActionResult Index() 
        {            
            return View();
        }

        // BodyMassIndex2
        [HttpGet] //get data from Form BodyMassIndex2
        public IActionResult BodyMassIndex2()
        {
            // accept Data
            return View();
        }
        [HttpPost] //Post data
        public IActionResult BodyMassIndex2(Person friend)
        {
            // # calculate Data section
            // already calculate at Models (Lesson153.cs)
            return View("BodyMassIndex2Result", friend); // paste object name friend
        }
    }
}
