using System.Collections.Generic;
using Baibaocao.net.Model.Entity;
using Baibaocao.net.Model.SearchBuilder;

namespace Baibaocao.net.Repository.Interface
{
    public interface ICategoryRepository
    {
        List<Category> findAll(CategorySearchBuilder builder);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
        bool ExistsName(string name, int excludeId);
        int CountBooks(int id);
    }
}
