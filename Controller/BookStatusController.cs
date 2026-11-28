using System.Collections.Generic;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Repository;
using Baibaocao.net.Service;
using Baibaocao.net.Service.InterfaceService;

namespace Baibaocao.net.Controller
{
    public class BookStatusController
    {
        private readonly IBookStatusService service = new BookStatusService(new BookStatusRepository());

        public List<BookStatusDTO> findAll(BookStatusSearchBuilder builder)
        {
            return service.findAll(builder);
        }

        public void UpdateCondition(int loanDetailId, string? condition, int fine)
        {
            service.UpdateCondition(loanDetailId, condition, fine);
        }
    }
}
