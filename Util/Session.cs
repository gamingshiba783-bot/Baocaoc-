using Baibaocao.net.Model.DTO;

namespace Baibaocao.net.Util
{
    // luu tai khoan dang dang nhap de cac form khac dung
    public static class Session
    {
        public static AccountDTO? CurrentUser { get; set; }
    }
}
