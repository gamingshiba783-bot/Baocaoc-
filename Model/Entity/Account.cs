using System;
using System.Collections.Generic;
using System.Text;

namespace Baibaocao.net.Model.Entity
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";   // khong luu mat khau goc
        public string FullName { get; set; } = "";
        public string Role { get; set; } = "USER";       // ADMIN / USER
        public DateTime? CreatedAt { get; set; }
    }
}
