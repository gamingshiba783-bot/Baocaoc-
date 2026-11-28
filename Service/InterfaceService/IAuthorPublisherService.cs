using System.Collections.Generic;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.SearchBuilder;

namespace Baibaocao.net.Service.InterfaceService
{
    public interface IAuthorService
    {
        List<AuthorDTO> findAll(AuthorSearchBuilder builder);
        void Add(AuthorDTO dto);
        void Update(AuthorDTO dto);
        void Delete(int id);
    }

    public interface IPublisherService
    {
        List<PublisherDTO> findAll(PublisherSearchBuilder builder);
        void Add(PublisherDTO dto);
        void Update(PublisherDTO dto);
        void Delete(int id);
    }
}
