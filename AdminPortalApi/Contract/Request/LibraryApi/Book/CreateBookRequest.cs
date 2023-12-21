using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.LibraryApi.Book
{
    public class CreateBookRequest
    {
        public string? name { get; set; }
        public int pageCount { get; set; }
        public int isbn { get; set; }
        public DateTime CreatedOn { get; set; }
        public int status { get; set; }

    }
}
