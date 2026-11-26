using System.Collections.Generic;
using System.Linq;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.Entity;

namespace Baibaocao.net.Converter
{
    public class ReaderConverter
    {//chuyen du lieu tu Reader entity qua ReaderDTO
        public static ReaderDTO toDTO(Reader r)
        {
            return new ReaderDTO
            {
                Ma = r.Id,
                HoTen = r.FullName ?? "",
                NgaySinh = r.DateOfBirth,
                GioiTinh = GenderToText(r.Gender),
                DiaChi = r.Address ?? "",
                SoDienThoai = r.Phone ?? "",
                NgayDangKy = r.RegistrationDate,
                NgayHetHan = r.ExpiryDate,
                TrangThai = r.Status == 1 ? "Hoạt động" : "Bị khóa"
            };
        }
        //chuyen danh sach entity thanh dto
        public static List<ReaderDTO> ToDTOs(IEnumerable<Reader> readers)
        {
            return readers.Select(toDTO).ToList();
        }

        public static Reader ToEntity(ReaderDTO d)
        {
            return new Reader
            {
                Id = d.Ma,
                FullName = d.HoTen,
                DateOfBirth = d.NgaySinh,
                Gender = TextToGender(d.GioiTinh),
                Address = d.DiaChi,
                Phone = d.SoDienThoai,
                RegistrationDate = d.NgayDangKy,
                ExpiryDate = d.NgayHetHan,
                Status = d.TrangThai == "Hoạt động" ? 1 : 0
            };
        }

        // trong CSDL luu MALE/FEMALE/OTHER, tren form hien Nam/Nữ/Khác
        public static string GenderToText(string? g)
        {
            switch (g)
            {
                case "MALE": return "Nam";
                case "FEMALE": return "Nữ";
                case "OTHER": return "Khác";
                default: return "";
            }
        }
        public static string? TextToGender(string text)
        {
            switch (text)
            {
                case "Nam": return "MALE";
                case "Nữ": return "FEMALE";
                case "Khác": return "OTHER";
                default: return null;
            }
        }
    }
}
