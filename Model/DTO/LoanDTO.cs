using System;
using System.Collections.Generic;

namespace Baibaocao.net.Model.DTO
{
    public class LoanDTO
    {
        public int Ma { get; set; }
        public string DocGia { get; set; } = "";
        public string TenSach { get; set; } = "";
        public DateTime NgayMuon { get; set; }
        public DateTime HanTra { get; set; }
        public DateTime? NgayTraThucTe { get; set; }
        public string TinhTrangTra { get; set; } = "";
        public string TrangThai { get; set; } = "";

        public string NhanVien { get; set; } = "";
        public int TienPhat { get; set; }
        public int EmployeeId { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }
        public int Status { get; set; } = 1;
        public List<LoanDetailDTO> Details { get; set; } = new List<LoanDetailDTO>();
    }
}
