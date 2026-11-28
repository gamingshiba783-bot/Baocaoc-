using System;
using System.Collections.Generic;
using System.Text;

namespace Baibaocao.net.Model.Entity
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName {  get; set; }
        public string Address {  get; set; }
        public int? BirthYear {  get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
