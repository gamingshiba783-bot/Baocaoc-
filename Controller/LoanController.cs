using System;
using System.Collections.Generic;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.Entity;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Repository;
using Baibaocao.net.Service;
using Baibaocao.net.Service.InterfaceService;

namespace Baibaocao.net.Controller
{
    public class LoanController
    {
        private readonly ILoanService service = new LoanService(new LoanRepository());

        public List<LoanDTO> findAll(LoanSearchBuilder builder)
        {
            return service.findAll(builder);
        }

        public void Add(LoanDTO loan)
        {
            service.Add(loan);
        }

        public void Update(LoanDTO loan)
        {
            service.Update(loan);
        }

        public void Delete(int id)
        {
            service.Delete(id);
        }

        public void ReturnBook(int loanId, int? bookId, DateTime actualReturnDate, string returnCondition, int employeeId)
        {
            service.ReturnBook(loanId, bookId, actualReturnDate, returnCondition, employeeId);
        }

        public List<Employee> GetEmployees()
        {
            return service.GetEmployees();
        }

        public List<Reader> GetReaders()
        {
            return service.GetReaders();
        }

        public List<Book> GetBooks()
        {
            return service.GetBooks();
        }
    }
}
