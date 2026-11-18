using System.Collections.Generic;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Model.Entity;
namespace Baibaocao.net.Repository.Interface
{
    public interface IBookRepository
    {
        List<Book> findAll(BookSearchBuilder builder);
        void Add(Book book);
        void Update(Book book);
        void Delete(int id);
        List<Publisher> findAllPublisher();
        List<Category> findAllCategory();
        List<Author> findAllAuthor();
    }
}
