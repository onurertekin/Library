using System;
using System.Collections.Generic;

namespace Contract.Response.LibraryApi.Book
{
    public class SearchBooksResponse
    {
        public class Books
        {
            public int id { get; set; }
            public string? name { get; set; }
            public int pageCount { get; set; }
            public int isbn { get; set; }
            public DateTime CreatedOn { get; set; }
            public DateTime? UpdatedOn { get; set; }
            public int status { get; set; }

        }
        public SearchBooksResponse()
        {
            books = new List<Books>();
        }
        public List<Books> books { get; set; }
        public int totalCount { get; set; }

    }
}
