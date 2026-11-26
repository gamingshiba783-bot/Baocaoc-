using System;
using System.Collections.Generic;
using System.Text;

namespace Baibaocao.net.Model.DTO
{
    // du lieu nhap tu form dang ky
    public class RegisterDTO
    {
        public string HoTen { get; set; } = "";
        public string TenDangNhap { get; set; } = "";
        public string MatKhau { get; set; } = "";
        public string XacNhanMatKhau { get; set; } = "";
    }
}
