namespace Core.Models
{
    public class Driver : BaseClass
    {
        public string? DriverName { get; set; }

        public Driver(string driverName)
        {
            DriverName = driverName;
        }

        public override bool Validate()
        {
            if (string.IsNullOrEmpty(DriverName))
            {
                return false;
            }

            return true;
        }
    }
}
