using System.Collections.Generic;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.SearchBuilder;

namespace Baibaocao.net.Service.InterfaceService
{
    public interface IBookStatusService
    {
        List<BookStatusDTO> findAll(BookStatusSearchBuilder builder);
        void UpdateCondition(int loanDetailId, string? condition, int fine);
    }
}
