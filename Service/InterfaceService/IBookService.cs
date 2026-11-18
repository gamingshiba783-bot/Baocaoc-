using System.Collections.Generic;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.Entity;

namespace Baibaocao.net.Service.InterfaceService
{
    public interface IBookService
    {
        List<BookDTO> findAll(BookSearchBuilder builder);
        void Add(BookDTO bookDTO);
        void Update(BookDTO bookDTO);
        void Delete(int id);
        List<Publisher>GetPublishers();
        List<Author>GetAuthors();
        List<Category>GetCategories();
    }
}
