using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.Entity;

namespace Baibaocao.net.Converter
{
    public class AccountConverter
    {//chuyen Account entity qua AccountDTO (bo mat khau)
        public static AccountDTO toDTO(Account a)
        {
            return new AccountDTO
            {
                Ma = a.Id,
                TenDangNhap = a.Username,
                HoTen = a.FullName,
                VaiTro = a.Role
            };
        }
    }
}
