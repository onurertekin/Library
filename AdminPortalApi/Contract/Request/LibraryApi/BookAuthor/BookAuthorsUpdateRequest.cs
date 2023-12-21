using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.LibraryApi.BookAuthor
{
    public class BookAuthorsUpdateRequest
    {
        public List<int> authors { get; set; }
    }
}
