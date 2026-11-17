using System;
using System.Collections.Generic;
using System.Text;

namespace Baibaocao.net.Model.Entity
{
    public class BookAuthor
    {
        public int Id { get; set; }

        public int BookID { get; set; }

        public int AuthorID { get; set; }

        public string Role { get; set; }

        public Book Book { get; set; }

        public Author Author { get; set; }
    }
}
