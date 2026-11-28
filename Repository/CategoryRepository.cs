using System.Collections.Generic;
using System.Linq;
using Baibaocao.net.DataAccess;
using Baibaocao.net.Model.Entity;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Baibaocao.net.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> findAll(CategorySearchBuilder b)
        {
            using (var db = new LibraryContext())
            {
                var query = db.Categories
                    .Include(x => x.bookCategories)
                    .AsNoTracking()
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(b.TenDanhMuc))
                    query = query.Where(x => x.CategoryName.Contains(b.TenDanhMuc));

                return query.OrderBy(x => x.Id).ToList();
            }
        }

        public void Add(Category category)
        {
            using (var db = new LibraryContext())
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }

        public void Update(Category category)
        {
            using (var db = new LibraryContext())
            {
                var old = db.Categories.FirstOrDefault(x => x.Id == category.Id);
                if (old == null) return;
                old.CategoryName = category.CategoryName;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new LibraryContext())
            {
                var old = db.Categories.FirstOrDefault(x => x.Id == id);
                if (old == null) return;
                db.Categories.Remove(old);
                db.SaveChanges();
            }
        }

        public bool ExistsName(string name, int excludeId)
        {
            using (var db = new LibraryContext())
                return db.Categories.Any(x => x.CategoryName == name && x.Id != excludeId);
        }

        public int CountBooks(int id)
        {
            using (var db = new LibraryContext())
                return db.BookCategories.Count(x => x.CategoryID == id);
        }
    }
}
