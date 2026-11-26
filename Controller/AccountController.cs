using Baibaocao.net.Model.DTO;
using Baibaocao.net.Repository;
using Baibaocao.net.Service;
using Baibaocao.net.Service.InterfaceService;

namespace Baibaocao.net.Controller
{
    public class AccountController
    {
        private readonly IAccountService service = new AccountService(new AccountRepository());

        public AccountDTO Login(string tenDangNhap, string matKhau)
        {
            return service.Login(tenDangNhap, matKhau);
        }
        public void Register(RegisterDTO dto)
        {
            service.Register(dto);
        }
    }
}
