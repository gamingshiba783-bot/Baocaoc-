using System.Collections.Generic;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Model.Entity;
namespace Baibaocao.net.Repository.Interface
{
    public interface IReaderRepository
    {
        List<Reader> findAll(ReaderSearchBuilder builder);
        void Add(Reader reader);
        void Update(Reader reader);
        void Delete(int id);
    }
}
