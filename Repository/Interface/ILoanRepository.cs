using System;
using System.Collections.Generic;
using Baibaocao.net.Model.Entity;
using Baibaocao.net.Model.SearchBuilder;

namespace Baibaocao.net.Repository.Interface
{
    public interface ILoanRepository
    {
        List<Loan> findAll(LoanSearchBuilder builder);
        void Add(Loan loan);
        void Update(Loan loan);
        void Delete(int id);
        void ReturnBook(int loanId, int? bookId, DateTime actualReturnDate, string returnCondition, int employeeId);
        List<Employee> findAllEmployee();
        List<Reader> findAllReader();
        List<Book> findAllBook();
    }
}
