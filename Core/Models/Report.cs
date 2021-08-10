using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Report
    {
        public string DriverName { get; set; }
        public decimal TotalDistanceInMiles { get; set; }
        public double TotalTimeTakenInHours { get; set; }
        public decimal AverageSpeed { get; set; }
    }
}
