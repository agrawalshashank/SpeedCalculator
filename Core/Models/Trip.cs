using System;

namespace Core.Models
{
    public class Trip : BaseClass
    {
        public Driver Driver { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal DistanceCovered { get; set; }

        public Trip(string driverName, string startTime, string endTime, string distanceCovered)
        {
            Driver = new Driver(driverName);
            StartTime = Convert.ToDateTime(startTime);
            EndTime = Convert.ToDateTime(endTime);
            DistanceCovered = Convert.ToDecimal(distanceCovered);
        }

        public override bool Validate()
        {
            if (string.IsNullOrEmpty(Driver.DriverName))
            {
                return false;
            }

            if(EndTime < StartTime)
            {
                return false;
            }

            if(DistanceCovered < 1)
            {
                return false;
            }

            return true;
        }
    }
}
