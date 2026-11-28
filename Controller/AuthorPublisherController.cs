using System.Collections.Generic;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Repository;
using Baibaocao.net.Service;
using Baibaocao.net.Service.InterfaceService;

namespace Baibaocao.net.Controller
{
    public class AuthorController
    {
        private readonly IAuthorService service = new AuthorService(new AuthorRepository());

        public List<AuthorDTO> findAll(AuthorSearchBuilder builder) => service.findAll(builder);
        public void Add(AuthorDTO dto) => service.Add(dto);
        public void Update(AuthorDTO dto) => service.Update(dto);
        public void Delete(int id) => service.Delete(id);
    }

    public class PublisherController
    {
        private readonly IPublisherService service = new PublisherService(new PublisherRepository());

        public List<PublisherDTO> findAll(PublisherSearchBuilder builder) => service.findAll(builder);
        public void Add(PublisherDTO dto) => service.Add(dto);
        public void Update(PublisherDTO dto) => service.Update(dto);
        public void Delete(int id) => service.Delete(id);
    }
}
