using System;
using System.Collections.Generic;
using System.Text;

namespace Baibaocao.net.Model.SearchBuilder
{
    public class BookSearchBuilder
    {
        public string? TenSach {  get; set; }
        public int?NamXuatBan { get; set; }
        public int? PublisherId {  get; set; }
        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }
    }
}
