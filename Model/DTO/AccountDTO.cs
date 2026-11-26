using System;
using System.Collections.Generic;
using System.Text;

namespace Baibaocao.net.Model.DTO
{
    // thong tin tai khoan sau khi dang nhap (khong co mat khau)
    public class AccountDTO
    {
        public int Ma { get; set; }
        public string TenDangNhap { get; set; } = "";
        public string HoTen { get; set; } = "";
        public string VaiTro { get; set; } = "";
    }
}
