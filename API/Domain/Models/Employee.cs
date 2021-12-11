using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    [Index(nameof(EmployeeNo), IsUnique = true)]
    public class Employee
    {
        public string EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeNo { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? DOB { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime JoinDate { get; set; }

        [NotMapped]
        public string DepartmentId { get; set; }

        public Department Department { get; set; }
        public decimal Salary { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Skills { get; set; }

        [Timestamp]
        public byte[] TS { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdatedDate { get; set; }

    }
}
