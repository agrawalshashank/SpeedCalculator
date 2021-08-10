using Core.Factories;
using Core.Models;
using Persistence.Contract;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class ReportService : IReportService
    {
        private readonly IRepository<Trip> repository;
        private readonly IRepository<Driver> driverRepository;

        public ReportService(IRepository<Trip> repository, IRepository<Driver> driverRepository)
        {
            this.repository = repository;
            this.driverRepository = driverRepository;
        }

        public string GenerateReport()
        {
            List<Report> reports = new List<Report>();
            ICollection<Trip> trips = repository.GetAll();

            foreach (var driver in driverRepository.GetAll())
            {
                var report = new Report();
                report.DriverName = driver.DriverName;

                var driverTrips = trips.Where(x => x.Driver.DriverName.ToLower() == driver.DriverName.ToLower());
                if (driverTrips.Any())
                {
                    report.TotalDistanceInMiles = driverTrips.Sum(x => x.DistanceCovered);
                    report.TotalTimeTakenInHours = driverTrips.Sum(x => (x.EndTime - x.StartTime).TotalHours);
                    report.AverageSpeed = report.TotalDistanceInMiles / Convert.ToDecimal(report.TotalTimeTakenInHours);
                }

                reports.Add(report);
            }

            // We can pass any value for the type of report we want
            var reportGenerator = ReportFactory.Create(Core.Enum.ReportEnum.String);
            return reportGenerator.GenerateReport(reports.OrderByDescending(x => x.TotalDistanceInMiles).ToList());
        }
    }
}
