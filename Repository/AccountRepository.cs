using Baibaocao.net.DataAccess;
using Baibaocao.net.Model.Entity;
using Baibaocao.net.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Baibaocao.net.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Account? findByUsername(string username)
        {
            using (var db = new LibraryContext())
                return db.Accounts.AsNoTracking().FirstOrDefault(x => x.Username == username);
        }

        public bool existsByUsername(string username)
        {
            using (var db = new LibraryContext())
                return db.Accounts.Any(x => x.Username == username);
        }

        public void Add(Account account)
        {
            using (var db = new LibraryContext())
            {
                db.Accounts.Add(account);
                db.SaveChanges();
            }
        }
    }
}
