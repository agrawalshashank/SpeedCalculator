using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ReportGenerator
{
    public class ReportAsString : BaseReportGenerator
    {
        public override string GenerateReport(List<Report> reports)
        {
            StringBuilder reportBuilder = new StringBuilder();
            foreach (var driverReport in reports)
            {
                reportBuilder.Append($"{driverReport.DriverName}:");
                reportBuilder.Append(Math.Round(driverReport.TotalDistanceInMiles));
                reportBuilder.Append(" miles ");

                if (driverReport.TotalDistanceInMiles > 0)
                {
                    reportBuilder.Append("@ ");
                    reportBuilder.Append(Math.Round(driverReport.AverageSpeed));
                    reportBuilder.Append(" mph");
                }
                reportBuilder.Append(Environment.NewLine);
            }

            return reportBuilder.ToString();
        }
    }
}
