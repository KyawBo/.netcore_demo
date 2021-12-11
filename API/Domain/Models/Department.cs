using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    public class Department
    {
        public string DepartmentId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        [Timestamp]
        public byte[] TS { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdatedDate { get; set; }

        public IList<Employee> Employees { get; set; } = new List<Employee>();
    }
}
