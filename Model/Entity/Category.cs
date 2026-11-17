using System;
using System.Collections.Generic;
using System.Text;

namespace Baibaocao.net.Model.Entity
{
    public class Category
    {
        public int Id {  get; set; }
        public string CategoryName {  get; set; }
        public ICollection<BookCategory> bookCategories { get; set; }

    }
}
