using System.Collections.Generic;

namespace Baibaocao.net.Model.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; } = "";
        public string FullName { get; set; } = "";
        public int RoleID { get; set; }
        public int Status { get; set; } = 1;

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
