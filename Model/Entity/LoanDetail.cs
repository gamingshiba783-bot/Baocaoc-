using System;

namespace Baibaocao.net.Model.Entity
{
    public class LoanDetail
    {
        public int Id { get; set; }
        public int LoanID { get; set; }
        public int BookID { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public string? ReturnCondition { get; set; }
        public int? ReturnedBy { get; set; }
        public int Fine { get; set; }

        public Loan? Loan { get; set; }
        public Book? Book { get; set; }
        public Employee? Returner { get; set; }
    }
}
