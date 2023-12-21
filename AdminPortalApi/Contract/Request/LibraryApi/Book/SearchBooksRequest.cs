using System;

namespace Contract.Request.LibraryApi.Book
{
    public class SearchBooksRequest : PaginatedRequest
    {
        public string? name { get; set; }
        public int pageCount { get; set; }
        public int isbn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int status { get; set; }

    }
}
