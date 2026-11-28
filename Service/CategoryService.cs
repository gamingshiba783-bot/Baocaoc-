using System;
using System.Collections.Generic;
using Baibaocao.net.Converter;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Repository.Interface;
using Baibaocao.net.Service.InterfaceService;

namespace Baibaocao.net.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public List<CategoryDTO> findAll(CategorySearchBuilder builder)
        {
            return CategoryConverter.ToDTOs(_repository.findAll(builder));
        }

        public void Add(CategoryDTO dto)
        {
            Validate(dto, 0);
            _repository.Add(CategoryConverter.ToEntity(dto));
        }

        public void Update(CategoryDTO dto)
        {
            if (dto.Ma <= 0) throw new Exception("Hãy chọn danh mục cần sửa");
            Validate(dto, dto.Ma);
            _repository.Update(CategoryConverter.ToEntity(dto));
        }

        public void Delete(int id)
        {
            if (id <= 0) throw new Exception("Hãy chọn danh mục cần xóa");
            var count = _repository.CountBooks(id);
            if (count > 0)
                throw new Exception($"Không thể xóa: còn {count} sách thuộc danh mục này");
            _repository.Delete(id);
        }

        private void Validate(CategoryDTO dto, int excludeId)
        {
            var name = dto.TenDanhMuc?.Trim() ?? "";
            if (name.Length == 0)
                throw new Exception("Tên danh mục không được để trống");
            if (name.Length > 100)
                throw new Exception("Tên danh mục tối đa 100 ký tự");
            if (_repository.ExistsName(name, excludeId))
                throw new Exception("Tên danh mục đã tồn tại");
        }
    }
}
