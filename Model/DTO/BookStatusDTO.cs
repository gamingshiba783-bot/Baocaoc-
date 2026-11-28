using System;

namespace Baibaocao.net.Model.DTO
{
    public class BookStatusDTO
    {
        public int Ma { get; set; }
        public int LoanId { get; set; }
        public string TenSach { get; set; } = "";
        public string DocGia { get; set; } = "";
        public DateTime NgayMuon { get; set; }
        public DateTime HanTra { get; set; }
        public DateTime? NgayTra { get; set; }
        public string TinhTrang { get; set; } = "";
        public int TienPhat { get; set; }
        public string NhanVienNhan { get; set; } = "";
        public string TrangThai { get; set; } = "";
    }
}
