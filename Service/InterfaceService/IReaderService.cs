using System.Collections.Generic;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Model.DTO;

namespace Baibaocao.net.Service.InterfaceService
{
    public interface IReaderService
    {
        List<ReaderDTO> findAll(ReaderSearchBuilder builder);
        void Add(ReaderDTO readerDTO);
        void Update(ReaderDTO readerDTO);
        void Delete(int id);
    }
}
