using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Contract
{
    public interface IReportGenerator
    {
        string GenerateReport(List<Report> reports);
    }
}
