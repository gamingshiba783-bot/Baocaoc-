using System;
using System.Collections.Generic;
using System.Linq;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.Entity;

namespace Baibaocao.net.Converter
{
    public class BookStatusConverter
    {
        public static BookStatusDTO toDTO(LoanDetail d)
        {
            var due = d.Loan?.DueDate ?? DateTime.MinValue;
            string trangThai;
            if (d.ActualReturnDate.HasValue) trangThai = "Đã trả";
            else if (due.Date < DateTime.Today) trangThai = "Quá hạn";
            else trangThai = "Chưa trả";

            return new BookStatusDTO
            {
                Ma = d.Id,
                LoanId = d.LoanID,
                TenSach = d.Book?.BookTitle ?? "",
                DocGia = d.Loan?.Reader?.FullName ?? "",
                NgayMuon = d.Loan?.BorrowDate ?? DateTime.MinValue,
                HanTra = due,
                NgayTra = d.ActualReturnDate,
                TinhTrang = d.ReturnCondition ?? "",
                TienPhat = d.Fine,
                NhanVienNhan = d.Returner?.FullName ?? "",
                TrangThai = trangThai
            };
        }

        public static List<BookStatusDTO> ToDTOs(IEnumerable<LoanDetail> details)
        {
            return details.Select(toDTO).ToList();
        }
    }
}
