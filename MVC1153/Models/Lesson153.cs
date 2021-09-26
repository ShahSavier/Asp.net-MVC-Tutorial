using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC1153.Models
{
    public class Person
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Gender { get; set; }
        public bool Smoking { get; set; }

        // Additional properties used by BMI App 2 (Vaccinnated)
        public bool Vaccinated { get; set; } // can use bool @ boolean
        public double Bmi
        {
            get // formula want to make calculation
            {
                return Weight / Math.Pow(Height, 2);
            } // * cannot use direct get and set sebab get & set akan direct fetch data sahaja
            set { }
        }
        public string BmiClass
        {
            get
            {
                if (Bmi < 18.5)
                    return "Underweight";
                else if (Bmi < 25)
                    return "Good";
                else if (Bmi < 29)
                    return "Overweight";
                else
                    return "Obese";
            }
            set { }
        }
    }
}
