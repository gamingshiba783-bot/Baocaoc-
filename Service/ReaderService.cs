using System;
using System.Collections.Generic;
using System.Linq;
using Baibaocao.net.Converter;
using Baibaocao.net.Model.SearchBuilder;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Service.InterfaceService;
using Baibaocao.net.Repository.Interface;

namespace Baibaocao.net.Service
{
    public class ReaderService : IReaderService
    {
        private readonly IReaderRepository _readerRepository;
        public ReaderService(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }
        public List<ReaderDTO> findAll(ReaderSearchBuilder builder)
        {
            return ReaderConverter.ToDTOs(_readerRepository.findAll(builder));
        }
        public void Add(ReaderDTO readerDTO)
        {
            Validate(readerDTO);
            _readerRepository.Add(ReaderConverter.ToEntity(readerDTO));
        }
        public void Update(ReaderDTO readerDTO)
        {
            if (readerDTO.Ma <= 0) throw new Exception("Hãy chọn độc giả cần sửa");
            Validate(readerDTO);
            _readerRepository.Update(ReaderConverter.ToEntity(readerDTO));
        }
        public void Delete(int id)
        {
            if (id <= 0) throw new Exception("Hãy chọn độc giả cần xóa");
            _readerRepository.Delete(id);
        }

        private void Validate(ReaderDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.HoTen))
                throw new Exception("Họ tên không được để trống");
            if (string.IsNullOrWhiteSpace(dto.GioiTinh))
                throw new Exception("Hãy chọn giới tính");
            if (dto.NgaySinh.HasValue && dto.NgaySinh.Value.Date >= DateTime.Today)
                throw new Exception("Ngày sinh không hợp lệ");
            if (string.IsNullOrWhiteSpace(dto.SoDienThoai))
                throw new Exception("Số điện thoại không được để trống");
            if (!dto.SoDienThoai.All(char.IsDigit) || dto.SoDienThoai.Length < 9 || dto.SoDienThoai.Length > 11)
                throw new Exception("Số điện thoại phải gồm 9-11 chữ số");
            if (dto.NgayDangKy.HasValue && dto.NgayHetHan.HasValue && dto.NgayHetHan.Value.Date <= dto.NgayDangKy.Value.Date)
                throw new Exception("Ngày hết hạn phải sau ngày đăng ký");
            if (dto.NgayHetHan.HasValue && dto.NgayHetHan.Value.Date < DateTime.Today)
                throw new Exception("Ngày hết hạn đã qua (trước ngày hôm nay). Hãy gia hạn thẻ cho độc giả");
            if (string.IsNullOrWhiteSpace(dto.TrangThai))
                throw new Exception("Hãy chọn trạng thái");
        }
    }
}
