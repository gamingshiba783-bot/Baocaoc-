using System;
using System.Collections.Generic;
using System.Linq;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.Entity;

namespace Baibaocao.net.Converter
{
    public class LoanConverter
    {
        public static LoanDetailDTO toDetailDTO(LoanDetail d)
        {
            return new LoanDetailDTO
            {
                MaChiTiet = d.Id,
                LoanId = d.LoanID,
                BookId = d.BookID,
                TenSach = d.Book?.BookTitle ?? "",
                NgayTraThucTe = d.ActualReturnDate,
                TinhTrangTra = d.ReturnCondition ?? "",
                ReturnedBy = d.ReturnedBy,
                TienPhat = d.Fine
            };
        }

        public static List<LoanDetailDTO> ToDetailDTOs(IEnumerable<LoanDetail> details)
        {
            return details.Select(toDetailDTO).ToList();
        }

        public static LoanDTO toDTO(Loan l)
        {
            var details = l.LoanDetails ?? new List<LoanDetail>();
            var firstDetail = details.FirstOrDefault();

            string trangThai;
            if (l.Status == 0)
                trangThai = "Đã trả";
            else if (l.Status == 2 || l.DueDate.Date < DateTime.Today)
                trangThai = "Quá hạn";
            else
                trangThai = "Đang mượn";

            var conditions = details
                .Select(x => x.ReturnCondition)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct();

            return new LoanDTO
            {
                Ma = l.Id,
                DocGia = l.Reader?.FullName ?? "",
                TenSach = string.Join(", ", details.Select(x => x.Book?.BookTitle ?? "").Where(t => !string.IsNullOrEmpty(t))),
                NgayMuon = l.BorrowDate,
                HanTra = l.DueDate,
                NgayTraThucTe = details.Select(x => x.ActualReturnDate).Where(d => d.HasValue).Max(),
                TinhTrangTra = string.Join(", ", conditions),
                TrangThai = trangThai,
                NhanVien = l.Employee?.FullName ?? "",
                EmployeeId = l.EmployeeID,
                TienPhat = details.Sum(x => x.Fine),
                ReaderId = l.ReaderID,
                BookId = firstDetail?.BookID ?? 0,
                Status = l.Status,
                Details = ToDetailDTOs(details)
            };
        }

        public static List<LoanDTO> ToDTOs(IEnumerable<Loan> loans)
        {
            return loans.Select(toDTO).ToList();
        }

        public static Loan ToEntity(LoanDTO d)
        {
            var loan = new Loan
            {
                Id = d.Ma,
                ReaderID = d.ReaderId,
                EmployeeID = d.EmployeeId,
                BorrowDate = d.NgayMuon.Date,
                DueDate = d.HanTra.Date,
                Status = d.Status
            };

            if (d.Details != null && d.Details.Count > 0)
            {
                foreach (var item in d.Details)
                {
                    loan.LoanDetails.Add(new LoanDetail
                    {
                        Id = item.MaChiTiet,
                        LoanID = d.Ma,
                        BookID = item.BookId,
                        ActualReturnDate = item.NgayTraThucTe?.Date,
                        ReturnCondition = string.IsNullOrWhiteSpace(item.TinhTrangTra) ? null : item.TinhTrangTra.Trim(),
                        ReturnedBy = item.ReturnedBy,
                        Fine = item.TienPhat
                    });
                }
            }
            else if (d.BookId > 0)
            {
                loan.LoanDetails.Add(new LoanDetail
                {
                    LoanID = d.Ma,
                    BookID = d.BookId,
                    ActualReturnDate = d.NgayTraThucTe?.Date,
                    ReturnCondition = string.IsNullOrWhiteSpace(d.TinhTrangTra) ? null : d.TinhTrangTra.Trim(),
                    ReturnedBy = d.NgayTraThucTe.HasValue ? d.EmployeeId : (int?)null,
                    Fine = d.TienPhat
                });
            }

            return loan;
        }
    }
}
