using System;
using System.Collections.Generic;
using System.Text;
using XamarinLabs.Models;

namespace XamarinLabs.ViewModels
{
    public class ReportsViewModel
    {
        public List<Report> Reports { get; set; } = new List<Report>();

        public ReportsViewModel()
        {
            Reports.Add(new Report()
            {
                ReportName = "Project Report",
                ReportDescription = "This is a report about the Project",
                IsCompleted = true
            });
            Reports.Add(new Report()
            {
                ReportName = "Testing",
                ReportDescription = "This is just a report to test our usecase",
                IsCompleted = true
            });
            Reports.Add(new Report()
            {
                ReportName = "Delivery",
                ReportDescription = "This is a report about delivery of the project",
                IsCompleted = false
            });
        }
    }
}
