using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace Baibaocao.net.Model.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string Bookname { get; set; }
        public string BookTitle { get; set; }
        public int PublishYear { get; set; }
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<BookAuthor> BooksAuthors { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }

    }
}
