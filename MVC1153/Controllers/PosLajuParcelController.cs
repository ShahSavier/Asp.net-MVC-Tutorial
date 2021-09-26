using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC1153.Models;

namespace MVC1153.Controllers
{
    public class PosLajuParcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ParcelDelivery()
        {
            //must sign value, if null will cause error
            PosLajuParcel parcel = new PosLajuParcel();
            parcel.IndexWeight = parcel.IndexZone = -1;
            return View(parcel); //pass parcell to view

            /** 
             a few method
            First method
            -> parcel.IndexWeight = -1;
               parcel.IndexZone = -1;

            Second method 
            -> parcel.IndexWeight = parcel.IndexZone = -1;

            use this method to assign select zone & select weight
             */
        }

        [HttpPost]
        public IActionResult ParcelDelivery(PosLajuParcel parcel)
        {
            if (ModelState.IsValid)
                return View("ParcelDeliveryInvoice", parcel);
            else
                return View(parcel);
            /**
             Before validation => return View("ParcelDeliveryInvoice", parcel);
             After validation =>
                    if (ModelState.IsValid)
                    return View("ParcelDeliveryInvoice", parcel);
                else
                    return View(parcel);
             */
        }
    }
}
