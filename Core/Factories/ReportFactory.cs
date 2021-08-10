using Core.Enum;
using Core.Models;
using Core.ReportGenerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Factories
{
    public static class ReportFactory
    {
        public static BaseReportGenerator Create(ReportEnum reportEnum)
        {
            switch (reportEnum)
            {
                case ReportEnum.String:
                    return new ReportAsString();
                    break;
                case ReportEnum.Excel:
                    // in future we need to download report as excel
                    break;
                default:
                    break;
            }

            return new ReportAsString();
        }
    }
}
