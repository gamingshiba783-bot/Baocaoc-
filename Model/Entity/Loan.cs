using System;
using System.Collections.Generic;

namespace Baibaocao.net.Model.Entity
{
    public class Loan
    {
        public int Id { get; set; }
        public int ReaderID { get; set; }
        public int EmployeeID { get; set; }
        public Employee? Employee { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public int Status { get; set; } = 1;

        public Reader? Reader { get; set; }
        public ICollection<LoanDetail> LoanDetails { get; set; } = new List<LoanDetail>();
    }
}
