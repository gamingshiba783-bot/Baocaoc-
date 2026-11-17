using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baibaocao.net.Model.Entity
{
    public class Publisher
    {
        public int Id {  get; set; }
        public string PublisherName { get; set; }
        public string Address { get; set; }
        public string Phone {get; set; }
        public string Email {  get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
