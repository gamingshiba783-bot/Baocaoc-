using System;
using System.Collections.Generic;
using Baibaocao.net.Converter;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.Entity;
using Baibaocao.net.Repository;
using Baibaocao.net.Service.InterfaceService;
using Baibaocao.net.Repository.Interface;

namespace Baibaocao.net.Service
{
    public class BookService : IBookService 
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public List<BookDTO> findAll(BookSearchBuilder builder)
        {
            return BookConverter.ToDTOs(_bookRepository.findAll(builder));
        }
        public void Add(BookDTO bookDTO) { 
            Validate(bookDTO);
            _bookRepository.Add(BookConverter.ToEntity(bookDTO));
        }
        public void Update(BookDTO bookDTO)
        {
            if (bookDTO.Ma <= 0) throw new Exception("Hay chon sach can sua");
            Validate(bookDTO);
            _bookRepository.Update(BookConverter.ToEntity(bookDTO));
        }
        public void Delete(int id) {
            if (id <= 0) throw new Exception("Hay chon sach can xoa ");
            _bookRepository.Delete(id);
        }
        public List<Publisher> GetPublishers() => _bookRepository.findAllPublisher();
        public List<Author> GetAuthors() => _bookRepository.findAllAuthor();
        public List<Category> GetCategories () => _bookRepository.findAllCategory();

        private void Validate(BookDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.TenSach))
                throw new Exception("Tên sách không được để trống");
            if (dto.NamXuatBan <= 0)
                throw new Exception("Năm xuất bản không hợp lệ");
            if (dto.PublisherId <= 0 || dto.AuthorId <= 0 || dto.CategoryId <= 0)
                throw new Exception("Hãy chọn nhà xuất bản, tác giả và thể loại");
        }
    }
}
