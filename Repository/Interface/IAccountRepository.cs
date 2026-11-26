using Baibaocao.net.Model.Entity;
namespace Baibaocao.net.Repository.Interface
{
    public interface IAccountRepository
    {
        Account? findByUsername(string username);
        bool existsByUsername(string username);
        void Add(Account account);
    }
}
