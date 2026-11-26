using System;
using System.Linq;
using Baibaocao.net.Converter;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.Entity;
using Baibaocao.net.Repository.Interface;
using Baibaocao.net.Service.InterfaceService;
using Baibaocao.net.Util;

namespace Baibaocao.net.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public AccountDTO Login(string tenDangNhap, string matKhau)
        {
            tenDangNhap = (tenDangNhap ?? "").Trim();
            if (tenDangNhap == "" || string.IsNullOrEmpty(matKhau))
                throw new Exception("Hãy nhập tên đăng nhập và mật khẩu");

            var account = _accountRepository.findByUsername(tenDangNhap);
            // bao chung 1 loi de khong lo ten dang nhap nao ton tai
            if (account == null || !PasswordUtil.Verify(matKhau, account.PasswordHash))
                throw new Exception("Sai tên đăng nhập hoặc mật khẩu");

            return AccountConverter.toDTO(account);
        }

        public void Register(RegisterDTO dto)
        {
            Validate(dto);
            var tenDangNhap = dto.TenDangNhap.Trim();
            if (_accountRepository.existsByUsername(tenDangNhap))
                throw new Exception("Tên đăng nhập đã tồn tại");

            _accountRepository.Add(new Account
            {
                Username = tenDangNhap,
                PasswordHash = PasswordUtil.Hash(dto.MatKhau),
                FullName = dto.HoTen.Trim(),
                Role = "USER",
                CreatedAt = DateTime.Now
            });
        }

        private void Validate(RegisterDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.HoTen))
                throw new Exception("Họ tên không được để trống");
            var ten = (dto.TenDangNhap ?? "").Trim();
            if (ten.Length < 4 || ten.Length > 50)
                throw new Exception("Tên đăng nhập phải từ 4 đến 50 ký tự");
            if (!ten.All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || char.IsDigit(c) || c == '_'))
                throw new Exception("Tên đăng nhập chỉ gồm chữ không dấu, số và dấu gạch dưới (_)");
            if (string.IsNullOrEmpty(dto.MatKhau) || dto.MatKhau.Length < 6)
                throw new Exception("Mật khẩu phải có ít nhất 6 ký tự");
            if (dto.MatKhau != dto.XacNhanMatKhau)
                throw new Exception("Mật khẩu nhập lại không khớp");
        }
    }
}
