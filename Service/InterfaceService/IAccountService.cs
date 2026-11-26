using Baibaocao.net.Model.DTO;

namespace Baibaocao.net.Service.InterfaceService
{
    public interface IAccountService
    {
        AccountDTO Login(string tenDangNhap, string matKhau);
        void Register(RegisterDTO dto);
    }
}
