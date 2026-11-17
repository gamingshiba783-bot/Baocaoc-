using System;
using System.Collections.Generic;
using System.Text;

namespace Baibaocao.net.Model.Entity
{
    public class BookCategory
    {
        public int Id { get; set; }

        public int BookID { get; set; }

        public int CategoryID { get; set; }

        public Book Book { get; set; }

        public Category Category { get; set; }
    }
}
