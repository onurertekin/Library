using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.GeekYaparApi.Categories
{
    public class SearchCategoriesResponse
    {

        public class Categories
        {
            public int id { get; set; }
            public string name { get; set; }
            public DateTime CreatedOn { get; set; }
            public DateTime? UpdatedOn { get; set; }
            public int status { get; set; }
        }

        public SearchCategoriesResponse()
        {
            categories = new List<Categories>();
        }

        public List<Categories> categories { get; set; }
        public int totalCount { get; set; }

    }
}
