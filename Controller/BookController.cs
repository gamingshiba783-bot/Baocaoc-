using System.Collections.Generic;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.Entity;
using Baibaocao.net.Repository;
using Baibaocao.net.Service;
using Baibaocao.net.Service;
using Baibaocao.net.Service.InterfaceService;

namespace Baibaocao.net.Controller
{
    public class BookController
    {
        private readonly IBookService service = new BookService(new BookRepository());

        public List<BookDTO> findAll(BookSearchBuilder builder)
        {
            return service.findAll(builder);
        }
        public void Add(BookDTO book)
        {
            service.Add(book);
        }
        public void Update(BookDTO book)
        {
            service.Update(book);
        }
        public void Delete(int id)
        {
            service.Delete(id);
        }
        public List<Publisher> GetPublishers()
        {
            return service.GetPublishers();
        }
        public List<Author> GetAuthors()
        {
         return   service.GetAuthors();
        }
        public List<Category> GetCategories()
        {
           return service.GetCategories();
        }
    }
}
