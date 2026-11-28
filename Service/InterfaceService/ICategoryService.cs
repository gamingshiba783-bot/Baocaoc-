using System.Collections.Generic;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.SearchBuilder;

namespace Baibaocao.net.Service.InterfaceService
{
    public interface ICategoryService
    {
        List<CategoryDTO> findAll(CategorySearchBuilder builder);
        void Add(CategoryDTO dto);
        void Update(CategoryDTO dto);
        void Delete(int id);
    }
}
