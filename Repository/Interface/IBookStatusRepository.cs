using System.Collections.Generic;
using Baibaocao.net.Model.Entity;
using Baibaocao.net.Model.SearchBuilder;

namespace Baibaocao.net.Repository.Interface
{
    public interface IBookStatusRepository
    {
        List<LoanDetail> findAll(BookStatusSearchBuilder builder);
        void UpdateCondition(int loanDetailId, string? condition, int fine);
    }
}
