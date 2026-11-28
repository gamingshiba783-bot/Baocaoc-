using System.Collections.Generic;
using Baibaocao.net.Model.Entity;
using Baibaocao.net.Model.SearchBuilder;

namespace Baibaocao.net.Repository.Interface
{
    public interface IAuthorRepository
    {
        List<Author> findAll(AuthorSearchBuilder builder);
        void Add(Author author);
        void Update(Author author);
        void Delete(int id);
        int CountBooks(int id);
    }

    public interface IPublisherRepository
    {
        List<Publisher> findAll(PublisherSearchBuilder builder);
        void Add(Publisher publisher);
        void Update(Publisher publisher);
        void Delete(int id);
        int CountBooks(int id);
    }
}
