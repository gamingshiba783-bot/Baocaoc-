using System;
using System.Collections.Generic;
using Baibaocao.net.Converter;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Repository.Interface;
using Baibaocao.net.Service.InterfaceService;

namespace Baibaocao.net.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public List<AuthorDTO> findAll(AuthorSearchBuilder builder)
            => AuthorConverter.ToDTOs(_repository.findAll(builder));

        public void Add(AuthorDTO dto)
        {
            Validate(dto);
            _repository.Add(AuthorConverter.ToEntity(dto));
        }

        public void Update(AuthorDTO dto)
        {
            if (dto.Ma <= 0) throw new Exception("Hãy chọn tác giả cần sửa");
            Validate(dto);
            _repository.Update(AuthorConverter.ToEntity(dto));
        }

        public void Delete(int id)
        {
            if (id <= 0) throw new Exception("Hãy chọn tác giả cần xóa");
            var count = _repository.CountBooks(id);
            if (count > 0)
                throw new Exception($"Không thể xóa: tác giả còn {count} sách");
            _repository.Delete(id);
        }

        private void Validate(AuthorDTO dto)
        {
            var name = dto.TenTacGia?.Trim() ?? "";
            if (name.Length == 0) throw new Exception("Tên tác giả không được để trống");
            if (name.Length > 150) throw new Exception("Tên tác giả tối đa 150 ký tự");
            if ((dto.DiaChi?.Length ?? 0) > 255) throw new Exception("Địa chỉ tối đa 255 ký tự");
            if (dto.NamSinh.HasValue && (dto.NamSinh.Value < 1 || dto.NamSinh.Value > DateTime.Today.Year))
                throw new Exception("Năm sinh không hợp lệ");
        }
    }

    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _repository;

        public PublisherService(IPublisherRepository repository)
        {
            _repository = repository;
        }

        public List<PublisherDTO> findAll(PublisherSearchBuilder builder)
            => PublisherConverter.ToDTOs(_repository.findAll(builder));

        public void Add(PublisherDTO dto)
        {
            Validate(dto);
            _repository.Add(PublisherConverter.ToEntity(dto));
        }

        public void Update(PublisherDTO dto)
        {
            if (dto.Ma <= 0) throw new Exception("Hãy chọn nhà xuất bản cần sửa");
            Validate(dto);
            _repository.Update(PublisherConverter.ToEntity(dto));
        }

        public void Delete(int id)
        {
            if (id <= 0) throw new Exception("Hãy chọn nhà xuất bản cần xóa");
            var count = _repository.CountBooks(id);
            if (count > 0)
                throw new Exception($"Không thể xóa: nhà xuất bản còn {count} sách");
            _repository.Delete(id);
        }

        private void Validate(PublisherDTO dto)
        {
            var name = dto.TenNXB?.Trim() ?? "";
            if (name.Length == 0) throw new Exception("Tên nhà xuất bản không được để trống");
            if (name.Length > 150) throw new Exception("Tên nhà xuất bản tối đa 150 ký tự");
            if ((dto.DiaChi?.Length ?? 0) > 255) throw new Exception("Địa chỉ tối đa 255 ký tự");
            if ((dto.DienThoai?.Trim().Length ?? 0) > 20) throw new Exception("Số điện thoại tối đa 20 ký tự");
            var email = dto.Email?.Trim() ?? "";
            if (email.Length > 100) throw new Exception("Email tối đa 100 ký tự");
            if (email.Length > 0 && !email.Contains('@')) throw new Exception("Email không hợp lệ");
        }
    }
}
