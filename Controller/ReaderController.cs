using System.Collections.Generic;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Repository;
using Baibaocao.net.Service;
using Baibaocao.net.Service.InterfaceService;

namespace Baibaocao.net.Controller
{
    public class ReaderController
    {
        private readonly IReaderService service = new ReaderService(new ReaderRepository());

        public List<ReaderDTO> findAll(ReaderSearchBuilder builder)
        {
            return service.findAll(builder);
        }
        public void Add(ReaderDTO reader)
        {
            service.Add(reader);
        }
        public void Update(ReaderDTO reader)
        {
            service.Update(reader);
        }
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
