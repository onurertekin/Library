using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.LibraryApi.BookCategory
{
    public class GetBookCategoriesResponse
    {
        public class BookCategories
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        public GetBookCategoriesResponse()
        {
            bookCategories = new List<BookCategories>();
        }
        public List<BookCategories> bookCategories { get; set; }
    }
}
