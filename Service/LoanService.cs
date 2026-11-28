using System;
using System.Collections.Generic;
using Baibaocao.net.Converter;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.Entity;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Repository.Interface;
using Baibaocao.net.Service.InterfaceService;

namespace Baibaocao.net.Service
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public List<LoanDTO> findAll(LoanSearchBuilder builder)
        {
            return LoanConverter.ToDTOs(_loanRepository.findAll(builder));
        }

        public void Add(LoanDTO loanDTO)
        {
            Validate(loanDTO);
            _loanRepository.Add(LoanConverter.ToEntity(loanDTO));
        }

        public void Update(LoanDTO loanDTO)
        {
            if (loanDTO.Ma <= 0)
                throw new Exception("Hãy chọn phiếu mượn cần sửa");
            Validate(loanDTO);
            _loanRepository.Update(LoanConverter.ToEntity(loanDTO));
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Hãy chọn phiếu mượn cần xóa");
            _loanRepository.Delete(id);
        }

        public void ReturnBook(int loanId, int? bookId, DateTime actualReturnDate, string returnCondition, int employeeId)
        {
            if (loanId <= 0)
                throw new Exception("Hãy chọn phiếu mượn cần trả sách");
            if (employeeId <= 0)
                throw new Exception("Hãy chọn nhân viên nhận sách trả");
            _loanRepository.ReturnBook(loanId, bookId, actualReturnDate, returnCondition, employeeId);
        }

        public List<Employee> GetEmployees() => _loanRepository.findAllEmployee();

        public List<Reader> GetReaders() => _loanRepository.findAllReader();

        public List<Book> GetBooks() => _loanRepository.findAllBook();

        private void Validate(LoanDTO dto)
        {
            if (dto.ReaderId <= 0)
                throw new Exception("Hãy chọn độc giả");
            if (dto.EmployeeId <= 0)
                throw new Exception("Hãy chọn nhân viên lập phiếu");
            if (dto.BookId <= 0 && (dto.Details == null || dto.Details.Count == 0))
                throw new Exception("Hãy chọn sách cần mượn");
            if (dto.HanTra.Date < dto.NgayMuon.Date)
                throw new Exception("Hạn trả phải lớn hơn hoặc bằng ngày mượn");
            if (dto.NgayTraThucTe.HasValue && dto.NgayTraThucTe.Value.Date < dto.NgayMuon.Date)
                throw new Exception("Ngày trả thực tế không thể nhỏ hơn ngày mượn");
        }
    }
}
