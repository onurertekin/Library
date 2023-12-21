using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.GeekYaparApi.Categories
{
    public class GetSingleCategoriesResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int status { get; set; }
    }
}
