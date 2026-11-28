using System.Collections.Generic;
using System.Linq;
using Baibaocao.net.DataAccess;
using Baibaocao.net.Model.Entity;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Baibaocao.net.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        public List<Author> findAll(AuthorSearchBuilder b)
        {
            using (var db = new LibraryContext())
            {
                var query = db.Authors.Include(x => x.BookAuthors).AsNoTracking().AsQueryable();
                if (!string.IsNullOrWhiteSpace(b.Keyword))
                    query = query.Where(x => x.AuthorName.Contains(b.Keyword));
                return query.OrderBy(x => x.Id).ToList();
            }
        }

        public void Add(Author author)
        {
            using (var db = new LibraryContext())
            {
                db.Authors.Add(author);
                db.SaveChanges();
            }
        }

        public void Update(Author author)
        {
            using (var db = new LibraryContext())
            {
                var old = db.Authors.FirstOrDefault(x => x.Id == author.Id);
                if (old == null) return;
                old.AuthorName = author.AuthorName;
                old.Address = author.Address;
                old.BirthYear = author.BirthYear;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new LibraryContext())
            {
                var old = db.Authors.FirstOrDefault(x => x.Id == id);
                if (old == null) return;
                db.Authors.Remove(old);
                db.SaveChanges();
            }
        }

        public int CountBooks(int id)
        {
            using (var db = new LibraryContext())
                return db.BookAuthors.Count(x => x.AuthorID == id);
        }
    }

    public class PublisherRepository : IPublisherRepository
    {
        public List<Publisher> findAll(PublisherSearchBuilder b)
        {
            using (var db = new LibraryContext())
            {
                var query = db.Publishers.Include(x => x.Books).AsNoTracking().AsQueryable();
                if (!string.IsNullOrWhiteSpace(b.Keyword))
                    query = query.Where(x => x.PublisherName.Contains(b.Keyword));
                return query.OrderBy(x => x.Id).ToList();
            }
        }

        public void Add(Publisher publisher)
        {
            using (var db = new LibraryContext())
            {
                db.Publishers.Add(publisher);
                db.SaveChanges();
            }
        }

        public void Update(Publisher publisher)
        {
            using (var db = new LibraryContext())
            {
                var old = db.Publishers.FirstOrDefault(x => x.Id == publisher.Id);
                if (old == null) return;
                old.PublisherName = publisher.PublisherName;
                old.Address = publisher.Address;
                old.Phone = publisher.Phone;
                old.Email = publisher.Email;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new LibraryContext())
            {
                var old = db.Publishers.FirstOrDefault(x => x.Id == id);
                if (old == null) return;
                db.Publishers.Remove(old);
                db.SaveChanges();
            }
        }

        public int CountBooks(int id)
        {
            using (var db = new LibraryContext())
                return db.Books.Count(x => x.PublisherID == id);
        }
    }
}
