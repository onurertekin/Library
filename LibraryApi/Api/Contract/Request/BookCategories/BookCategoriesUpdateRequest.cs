using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.BookCategories
{
    public class BookCategoriesUpdateRequest
    {
        public List<int> categories { get; set; }
    }
}
