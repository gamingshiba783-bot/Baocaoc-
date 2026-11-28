using System;

namespace Baibaocao.net.Model.DTO
{
    public class LoanDetailDTO
    {
        public int MaChiTiet { get; set; }
        public int LoanId { get; set; }
        public int BookId { get; set; }
        public string TenSach { get; set; } = "";
        public DateTime? NgayTraThucTe { get; set; }
        public string TinhTrangTra { get; set; } = "";
        public int? ReturnedBy { get; set; }
        public int TienPhat { get; set; }
    }
}
