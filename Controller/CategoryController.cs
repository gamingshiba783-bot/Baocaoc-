using System.Collections.Generic;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Repository;
using Baibaocao.net.Service;
using Baibaocao.net.Service.InterfaceService;

namespace Baibaocao.net.Controller
{
    public class CategoryController
    {
        private readonly ICategoryService service = new CategoryService(new CategoryRepository());

        public List<CategoryDTO> findAll(CategorySearchBuilder builder)
        {
            return service.findAll(builder);
        }

        public void Add(CategoryDTO dto)
        {
            service.Add(dto);
        }

        public void Update(CategoryDTO dto)
        {
            service.Update(dto);
        }

        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
