using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.Authors
{
    public class SearchAuthorsResponse
    {
        public class Authors
        {
            public int id { get; set; }
            public string name { get; set; }
            public DateTime CreatedOn { get; set; }
            public DateTime? UpdatedOn { get; set; }
            public int status { get; set; }
        }
        public SearchAuthorsResponse()
        {
            authors = new List<Authors>();
        }
        public List<Authors> authors { get; set; }
        public int totalCount { get; set; }
    }
}
