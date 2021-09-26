using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC1153.Models
{
    public class PosLajuParcel
    {
        //Properties for Sender
        [Required(ErrorMessage = "Enter Sender Name")]
        public string SenderName { get; set; }
        [Required(ErrorMessage = "Enter Sender Address")]
        public string SenderAddress { get; set; }
        [Required(ErrorMessage = "Enter Sender Phone Number")]
        public string SenderPhone { get; set; }
        public string SenderEmail { get; set; }

        //Properties for Receiver
        [Required(ErrorMessage = "Enter Receiver Name")]
        public string ReceiverName { get; set; }
        [Required(ErrorMessage = "Enter Sender Address")]
        public string ReceiverAddress { get; set; }
        [Required(ErrorMessage = "Enter Sender Phone Number")]
        public string ReceiverPhone { get; set; }
        public string ReceiverEmail { get; set; }


        // Properties for Parcel
        // Store index & zone here
        [Required]
        public int IndexWeight { get; set; }
        [Required]
        public int IndexZone { get; set; }

        // Store Amount
        // Before this using :- public double Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double Amount
        {
            get
            {
                return rates[IndexWeight, IndexZone];
            }
            set { }
        }
        /**
         Untuk format amount, xboleh direct convert 
         perlu import =>  using System.ComponentModel.DataAnnotations;
        and perlu letak diatas double yang hendak diubah => [DisplayFormat(DataFormatString ="{0:n2}")]
         */

        // add array in model
        // Parcel Delivery Rate Table

        double[,] rates = /*2 dimensional array*/
        {
            { 6.00 , 8.50, 9.00 },
            { 7.00, 10.50, 12.00 },
            { 8.50, 12.50, 14.50 },
            { 10.00, 14.50, 17.00 },
            { 11.00, 16.50, 20.00 },
            { 12.50, 18.50, 22.50 },
            { 14.00, 20.50, 25.00 },
            { 21.00, 34.50, 41.00 },
            { 24.00, 39.00, 46.00 }
        };

        // Dictionary Part for Weight Category & Zone
        public IDictionary<int/*Nilai index starting 0 untill 8*/, string/*Type of weight*/> DictWeight
        {
            get
            {
                return new Dictionary<int, string>()
                {
                    {0, "< 0.50 Kg" },
                    {1, "< 0.75 Kg" },
                    {2, "< 1.00 Kg" },
                    {3, "< 1.25 Kg" },
                    {4, "< 1.50 Kg" },
                    {5, "< 1.75 Kg" },
                    {6, "< 2.00 Kg" },
                    {7, "< 2.50 Kg" },
                    {8, "< 3.00 Kg" }
                };
            }
        }

        public IDictionary<int/*Nilai index starting 0 untill 8*/, string/*Type of zone*/> DictZone
        {
            get
            {
                return new Dictionary<int, string>()
                {
                    {0, " West Malaysia " },
                    {1, " Sarawak " },
                    {2, " Sabah " }
                };
            }
        }
        public DateTime ParcelDateTime
        {
            get
            {
                return DateTime.Now;
            }
            set { }
        }
        public string ParcelId
        {
            get
            {
                string hexTicks = DateTime.Now.Ticks.ToString("x");
                return hexTicks.Substring(hexTicks.Length - 15, 10);
            }

            set { }
        }
    }
}
