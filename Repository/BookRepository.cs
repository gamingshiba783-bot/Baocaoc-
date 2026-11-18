using Baibaocao.net.DataAccess;
using Baibaocao.net.Model.Entity;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Baibaocao.net.Repository
{
    public class BookRepository : IBookRepository
    {
        public List<Book> findAll(BookSearchBuilder b)
        {
            using (var db = new LibraryContext())
            {
                var query = db.Books
                    .Include(x => x.Publisher)
                    .Include(x => x.BooksAuthors).ThenInclude(ba => ba.Author)
                    .Include(x => x.BookCategories).ThenInclude(bc => bc.Category)
                    .AsNoTracking()
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(b.TenSach))
                    query = query.Where(x => x.BookTitle.Contains(b.TenSach));
                if (b.NamXuatBan.HasValue)
                    query = query.Where(x => x.PublishYear == b.NamXuatBan.Value);
                if (b.PublisherId.HasValue)
                    query = query.Where(x => x.PublisherID == b.PublisherId.Value);
                if (b.AuthorId.HasValue)
                    query = query.Where(x => x.BooksAuthors.Any(ba => ba.AuthorID == b.AuthorId.Value));
                if (b.CategoryId.HasValue)
                    query = query.Where(x => x.BookCategories.Any(bc => bc.CategoryID == b.CategoryId.Value));
                return query.OrderBy(x => x.Id).ToList();
            }
        }

        public void Add(Book book)
        {
            using (var db = new LibraryContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        public void Update(Book book)
        {
            using (var db = new LibraryContext())
            {
                var old = db.Books
                    .Include(x => x.BooksAuthors)
                    .Include(x => x.BookCategories)
                    .FirstOrDefault(x => x.Id == book.Id);
                if (old == null) return;

                old.BookTitle = book.BookTitle;
                old.Bookname = book.Bookname;
                old.PublishYear = book.PublishYear;
                old.PublisherID = book.PublisherID;

                db.BookAuthors.RemoveRange(old.BooksAuthors);
                db.BookCategories.RemoveRange(old.BookCategories);
                foreach (var ba in book.BooksAuthors)
                {
                    db.BookAuthors.Add(new BookAuthor
                    {
                        BookID = old.Id,
                        AuthorID = ba.AuthorID,
                        Role = ba.Role
                    });
                }
                foreach (var bc in book.BookCategories)
                {
                    db.BookCategories.Add(new BookCategory
                    {
                        BookID = old.Id,
                        CategoryID = bc.CategoryID
                    });
                }
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var db = new LibraryContext())
            {
                var book = db.Books
                    .Include(x => x.BooksAuthors)
                    .Include(x => x.BookCategories)
                    .FirstOrDefault(x => x.Id == id);
                if (book == null) return;
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

        public List<Publisher> findAllPublisher()
        {
            using(var db = new LibraryContext())
                return db.Publishers.AsNoTracking().ToList();
        }
        public List<Author> findAllAuthor()
        {
            using(var db = new LibraryContext())
                return db.Authors.AsNoTracking().ToList();
        }
        public List<Category> findAllCategory()
        {
            using (var  db = new LibraryContext())
                return db.Categories.AsNoTracking().ToList();
        }
    }
}
