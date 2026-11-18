using System;
using System.Collections.Generic;
using System.Text;

namespace Baibaocao.net.Model.DTO
{
    public class BookDTO
    {
        public int Ma {  get; set; }
        public string TenSach { get; set; } = "";
        public string NhaXuatBan { get; set; } = "";
        public int NamXuatBan { get; set; }
        public string TacGia { get; set; } = "";
        public string TheLoai { get; set; } = "";

        public int PublisherId {  get; set; }
        public int AuthorId { get; set; }
        public int CategoryId {  get; set; }
    }
}
