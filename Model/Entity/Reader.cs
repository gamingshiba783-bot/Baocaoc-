using System;
using System.Collections.Generic;
using System.Text;

namespace Baibaocao.net.Model.Entity
{
    public class Reader
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }          // MALE / FEMALE / OTHER
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? Status { get; set; }              // 1 = hoat dong, 0 = bi khoa
    }
}
