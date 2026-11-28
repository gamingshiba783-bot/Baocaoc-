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
    public class LoanRepository : ILoanRepository
    {
        public List<Loan> findAll(LoanSearchBuilder b)
        {
            using (var db = new LibraryContext())
            {
                var query = db.Loans
                    .Include(x => x.Reader)
                    .Include(x => x.Employee)
                    .Include(x => x.LoanDetails).ThenInclude(ld => ld.Book)
                    .AsNoTracking()
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(b.Keyword))
                {
                    var kw = b.Keyword.Trim();
                    query = query.Where(x =>
                        (x.Reader != null && x.Reader.FullName.Contains(kw)) ||
                        x.LoanDetails.Any(ld => ld.Book != null && ld.Book.BookTitle.Contains(kw)));
                }
                if (b.ReaderId.HasValue)
                    query = query.Where(x => x.ReaderID == b.ReaderId.Value);
                if (b.BookId.HasValue)
                    query = query.Where(x => x.LoanDetails.Any(ld => ld.BookID == b.BookId.Value));
                if (b.Status.HasValue)
                    query = query.Where(x => x.Status == b.Status.Value);
                if (b.FromDate.HasValue)
                    query = query.Where(x => x.BorrowDate >= b.FromDate.Value.Date);
                if (b.ToDate.HasValue)
                    query = query.Where(x => x.BorrowDate <= b.ToDate.Value.Date);

                return query.OrderBy(x => x.Id).ToList();
            }
        }

        public void Add(Loan loan)
        {
            using (var db = new LibraryContext())
            {
                db.Loans.Add(loan);
                db.SaveChanges();
            }
        }

        public void Update(Loan loan)
        {
            using (var db = new LibraryContext())
            {
                var old = db.Loans
                    .Include(x => x.LoanDetails)
                    .FirstOrDefault(x => x.Id == loan.Id);
                if (old == null) return;

                old.ReaderID = loan.ReaderID;
                old.EmployeeID = loan.EmployeeID;
                old.BorrowDate = loan.BorrowDate;
                old.DueDate = loan.DueDate;
                old.Status = loan.Status;

                db.LoanDetails.RemoveRange(old.LoanDetails);
                foreach (var ld in loan.LoanDetails)
                {
                    db.LoanDetails.Add(new LoanDetail
                    {
                        LoanID = old.Id,
                        BookID = ld.BookID,
                        ActualReturnDate = ld.ActualReturnDate,
                        ReturnCondition = ld.ReturnCondition,
                        ReturnedBy = ld.ReturnedBy,
                        Fine = ld.Fine
                    });
                }
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new LibraryContext())
            {
                var loan = db.Loans
                    .Include(x => x.LoanDetails)
                    .FirstOrDefault(x => x.Id == id);
                if (loan == null) return;

                db.LoanDetails.RemoveRange(loan.LoanDetails);
                db.Loans.Remove(loan);
                db.SaveChanges();
            }
        }

        public void ReturnBook(int loanId, int? bookId, DateTime actualReturnDate, string returnCondition, int employeeId)
        {
            using (var db = new LibraryContext())
            {
                var loan = db.Loans
                    .Include(x => x.LoanDetails)
                    .FirstOrDefault(x => x.Id == loanId);
                if (loan == null) throw new Exception("Không tìm thấy phiếu mượn");

                var targets = bookId.HasValue && bookId.Value > 0
                    ? loan.LoanDetails.Where(ld => ld.BookID == bookId.Value).ToList()
                    : loan.LoanDetails.Where(ld => !ld.ActualReturnDate.HasValue).ToList();

                if (targets.Count == 0)
                    targets = loan.LoanDetails.ToList();

                foreach (var detail in targets)
                {
                    detail.ActualReturnDate = actualReturnDate.Date;
                    detail.ReturnCondition = string.IsNullOrWhiteSpace(returnCondition) ? "Tốt" : returnCondition.Trim();
                    detail.ReturnedBy = employeeId;
                }

                if (loan.LoanDetails.All(ld => ld.ActualReturnDate.HasValue))
                {
                    loan.Status = 0;
                }

                db.SaveChanges();
            }
        }

        public List<Employee> findAllEmployee()
        {
            using (var db = new LibraryContext())
                return db.Employees.AsNoTracking().Where(e => e.Status == 1).OrderBy(e => e.Id).ToList();
        }

        public List<Reader> findAllReader()
        {
            using (var db = new LibraryContext())
                return db.Readers.AsNoTracking().OrderBy(r => r.Id).ToList();
        }

        public List<Book> findAllBook()
        {
            using (var db = new LibraryContext())
                return db.Books.AsNoTracking().OrderBy(b => b.Id).ToList();
        }
    }
}
