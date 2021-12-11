using System;
using API.Domain.Models;

namespace API.Resources
{
    public class EmployeeResource
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeNo { get; set; }
        public DateTime DOB { get; set; }
        public DateTime JoinDate { get; set; }
        public string DepartmentId { get; set; }
        public string Skills { get; set; }
        public decimal Salary { get; set; }
    }
}
