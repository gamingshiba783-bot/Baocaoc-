using System.Collections.Generic;
using System.Linq;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.Entity;

namespace Baibaocao.net.Converter
{
    public class CategoryConverter
    {
        public static CategoryDTO toDTO(Category c)
        {
            return new CategoryDTO
            {
                Ma = c.Id,
                TenDanhMuc = c.CategoryName ?? "",
                SoSach = c.bookCategories?.Count ?? 0
            };
        }

        public static List<CategoryDTO> ToDTOs(IEnumerable<Category> categories)
        {
            return categories.Select(toDTO).ToList();
        }

        public static Category ToEntity(CategoryDTO d)
        {
            return new Category
            {
                Id = d.Ma,
                CategoryName = d.TenDanhMuc.Trim()
            };
        }
    }
}
