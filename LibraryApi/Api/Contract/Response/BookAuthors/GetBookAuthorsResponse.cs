using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.BooksAuthors
{
    public class GetBookAuthorsResponse
    {
        public class BookAuthors
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        public GetBookAuthorsResponse()
        {
            bookAuthors = new List<BookAuthors>();
        }
        public List<BookAuthors> bookAuthors { get; set; }
    }
}
