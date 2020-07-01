using System;

namespace Ado.Net.Web.Models.Dto
{
    public class EmployeeDetailsDto
    {
        public int EmployeeID { get; set; }

        public string FullName { get; set; }

        public decimal Salary { get; set; }

        public string DepartamentName { get; set; }

        public string HireDate { get; set; }
    }
}
