using System.Collections.Generic;
using System.Linq;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.Entity;

namespace Baibaocao.net.Converter
{
    public class BookConverter
    {//hoan doi du lieu tu Bookentity qua BookDTO
        public static BookDTO toDTO(Book b)
         { //tao mot doi tuong BookDTO moi
            return new BookDTO
            {
                Ma = b.Id,
                TenSach = b.BookTitle,
                NhaXuatBan = b.Publisher?.PublisherName ?? "",
                NamXuatBan = b.PublishYear,
                TacGia = string.Join(", ", b.BooksAuthors.Select(x => x.Author?.AuthorName ?? "")),
                TheLoai = string.Join(", ", b.BookCategories.Select(x => x.Category?.CategoryName ?? "")),
                PublisherId = b.PublisherID,
                AuthorId = b.BooksAuthors.Select(x => x.AuthorID).FirstOrDefault(),
                CategoryId = b.BookCategories.Select(x => x.CategoryID).FirstOrDefault()
            };

        }
        //chuyen danh sach entity thanh dto
        public static List<BookDTO> ToDTOs(IEnumerable<Book> books) {
            return books.Select(toDTO).ToList();
        }

        public static Book ToEntity(BookDTO d)
        {
            var book = new Book
            {
                Id = d.Ma,
                BookTitle = d.TenSach,
                Bookname = d.TenSach,
                PublishYear = d.NamXuatBan,
                PublisherID = d.PublisherId


            };
            book.BooksAuthors.Add(new BookAuthor { AuthorID = d.AuthorId, Role = "Tac gia" });
            book.BookCategories.Add(new BookCategory { CategoryID = d.CategoryId });
            return book;
        }
    }
}
