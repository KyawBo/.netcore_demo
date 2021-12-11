namespace API.Domain.Models.Queries
{
    public class EmployeeQuery : Query
    {
        public string? _employeeName { get; set; }
        public string? _employeeNo { get; set; }

        public EmployeeQuery(string? employeeName, string? employeeNo, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            _employeeName = employeeName;
            _employeeNo = employeeNo;
        }
    }
}
