using System;
using System.Collections.Generic;
using Baibaocao.net.Converter;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Repository.Interface;
using Baibaocao.net.Service.InterfaceService;

namespace Baibaocao.net.Service
{
    public class BookStatusService : IBookStatusService
    {
        private readonly IBookStatusRepository _repository;

        public BookStatusService(IBookStatusRepository repository)
        {
            _repository = repository;
        }

        public List<BookStatusDTO> findAll(BookStatusSearchBuilder builder)
        {
            return BookStatusConverter.ToDTOs(_repository.findAll(builder));
        }

        public void UpdateCondition(int loanDetailId, string? condition, int fine)
        {
            if (loanDetailId <= 0)
                throw new Exception("Hãy chọn một dòng cần cập nhật");
            if (fine < 0)
                throw new Exception("Tiền phạt không được âm");
            _repository.UpdateCondition(loanDetailId, condition, fine);
        }
    }
}
