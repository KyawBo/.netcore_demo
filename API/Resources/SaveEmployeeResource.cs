using System;
using System.ComponentModel.DataAnnotations;

namespace API.Resources
{
    public class SaveEmployeeResource
    {
        [Required]
        [MaxLength(50)]
        public string EmployeeName { get; set; }

        [Required]
        [MaxLength(10)]
        public string EmployeeNo { get; set; }

        [Required]
        public DateTime? DOB { get; set; }

        [Required]
        public DateTime? JoinDate { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public string Skills { get; set; }

        [Required]
        public string DepartmentId { get; set; }
    }
}
