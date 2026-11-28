using System;
using System.Collections.Generic;
using System.Linq;
using Baibaocao.net.DataAccess;
using Baibaocao.net.Model.Entity;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Baibaocao.net.Repository
{
    public class BookStatusRepository : IBookStatusRepository
    {
        public List<LoanDetail> findAll(BookStatusSearchBuilder b)
        {
            using (var db = new LibraryContext())
            {
                var today = DateTime.Today;
                var query = db.LoanDetails
                    .Include(x => x.Book)
                    .Include(x => x.Returner)
                    .Include(x => x.Loan).ThenInclude(l => l!.Reader)
                    .AsNoTracking()
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(b.Keyword))
                {
                    var kw = b.Keyword.Trim();
                    query = query.Where(x =>
                        (x.Book != null && x.Book.BookTitle.Contains(kw)) ||
                        (x.Loan != null && x.Loan.Reader != null && x.Loan.Reader.FullName.Contains(kw)));
                }
                if (b.State == 1)
                    query = query.Where(x => x.ActualReturnDate == null && x.Loan!.DueDate >= today);
                else if (b.State == 2)
                    query = query.Where(x => x.ActualReturnDate == null && x.Loan!.DueDate < today);
                else if (b.State == 3)
                    query = query.Where(x => x.ActualReturnDate != null);

                if (!string.IsNullOrWhiteSpace(b.Condition))
                    query = query.Where(x => x.ReturnCondition == b.Condition);

                return query.OrderBy(x => x.Id).ToList();
            }
        }

        public void UpdateCondition(int loanDetailId, string? condition, int fine)
        {
            using (var db = new LibraryContext())
            {
                var detail = db.LoanDetails.FirstOrDefault(x => x.Id == loanDetailId);
                if (detail == null) throw new Exception("Không tìm thấy bản ghi");
                detail.ReturnCondition = string.IsNullOrWhiteSpace(condition) ? null : condition.Trim();
                detail.Fine = fine;
                db.SaveChanges();
            }
        }
    }
}
