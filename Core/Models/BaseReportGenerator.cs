using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public abstract class BaseReportGenerator
    {
        public abstract string GenerateReport(List<Report> reports);
    }
}
