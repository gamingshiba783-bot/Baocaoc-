using Baibaocao.net.DataAccess;
using Baibaocao.net.Model.Entity;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Baibaocao.net.Repository
{
    public class ReaderRepository : IReaderRepository
    {
        public List<Reader> findAll(ReaderSearchBuilder b)
        {
            using (var db = new LibraryContext())
            {
                var query = db.Readers.AsNoTracking().AsQueryable();

                if (!string.IsNullOrWhiteSpace(b.HoTen))
                    query = query.Where(x => x.FullName.Contains(b.HoTen));
                if (!string.IsNullOrWhiteSpace(b.SoDienThoai))
                    query = query.Where(x => x.Phone != null && x.Phone.Contains(b.SoDienThoai));
                if (b.TrangThai.HasValue)
                    query = query.Where(x => x.Status == b.TrangThai.Value);
                return query.OrderBy(x => x.Id).ToList();
            }
        }

        public void Add(Reader reader)
        {
            using (var db = new LibraryContext())
            {
                db.Readers.Add(reader);
                db.SaveChanges();
            }
        }

        public void Update(Reader reader)
        {
            using (var db = new LibraryContext())
            {
                var old = db.Readers.FirstOrDefault(x => x.Id == reader.Id);
                if (old == null) return;

                old.FullName = reader.FullName;
                old.DateOfBirth = reader.DateOfBirth;
                old.Gender = reader.Gender;
                old.Address = reader.Address;
                old.Phone = reader.Phone;
                old.RegistrationDate = reader.RegistrationDate;
                old.ExpiryDate = reader.ExpiryDate;
                old.Status = reader.Status;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new LibraryContext())
            {
                var reader = db.Readers.FirstOrDefault(x => x.Id == id);
                if (reader == null) return;
                db.Readers.Remove(reader);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    // bang Loan co khoa ngoai toi Reader
                    throw new Exception("Độc giả này đã có phiếu mượn, không thể xóa. Hãy chuyển trạng thái sang 'Bị khóa'.");
                }
            }
        }
    }
}
