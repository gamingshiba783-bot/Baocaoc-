using System;
using System.Collections.Generic;
using System.Text;

namespace Baibaocao.net.Model.DTO
{
    public class ReaderDTO
    {
        public int Ma { get; set; }
        public string HoTen { get; set; } = "";
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; } = "";      // Nam / Nữ / Khác
        public string DiaChi { get; set; } = "";
        public string SoDienThoai { get; set; } = "";
        public DateTime? NgayDangKy { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public string TrangThai { get; set; } = "";     // Hoạt động / Bị khóa
    }
}
