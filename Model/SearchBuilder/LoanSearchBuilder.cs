using System;

namespace Baibaocao.net.Model.SearchBuilder
{
    public class LoanSearchBuilder
    {
        public string? Keyword { get; set; }
        public int? ReaderId { get; set; }
        public int? BookId { get; set; }
        public int? Status { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
