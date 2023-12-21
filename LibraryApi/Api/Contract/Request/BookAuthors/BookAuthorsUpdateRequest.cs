using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.BookAuthors
{
    public class BookAuthorsUpdateRequest
    {
        public List<int> authors { get; set; }
    }
}
