using System;

namespace API.Infrastructure.Models
{
    internal class EmployeeRawModel
    {
        public string EmployeeName { get; set; }
        public string EmployeeNo { get; set; } 
        public string DepartmentId { get; set; }
        public DateTime DOB { get; set; }
        public DateTime JoinDate { get; set; }
        public string Skills { get; set; }
        public decimal Salary { get; set; }

        public static EmployeeRawModel FromCsv(string csvLine)
        {
            var values = csvLine.Split(';');
            var rawModel = new EmployeeRawModel
            {
                EmployeeName = values[0],
                EmployeeNo = values[1],
                DepartmentId = values[2],
                DOB = DateTime.ParseExact(values[3], "dd/MM/yyyy", null),
                JoinDate = DateTime.ParseExact(values[4], "dd/MM/yyyy", null),
                Salary = Convert.ToDecimal(values[5]),
                Skills = values[6],
            };
            return rawModel;
        }
    }
}
