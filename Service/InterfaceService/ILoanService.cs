using System;
using System.Collections.Generic;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.Entity;
using Baibaocao.net.Model.SearchBuilder;

namespace Baibaocao.net.Service.InterfaceService
{
    public interface ILoanService
    {
        List<LoanDTO> findAll(LoanSearchBuilder builder);
        void Add(LoanDTO loanDTO);
        void Update(LoanDTO loanDTO);
        void Delete(int id);
        void ReturnBook(int loanId, int? bookId, DateTime actualReturnDate, string returnCondition, int employeeId);
        List<Employee> GetEmployees();
        List<Reader> GetReaders();
        List<Book> GetBooks();
    }
}
