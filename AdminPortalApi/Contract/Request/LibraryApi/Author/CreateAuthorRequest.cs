using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.LibraryApi.Author
{
    public class CreateAuthorRequest
    {
        public string name { get; set; }
        public DateTime CreatedOn { get; set; }
        public int status { get; set; }
    }
}
