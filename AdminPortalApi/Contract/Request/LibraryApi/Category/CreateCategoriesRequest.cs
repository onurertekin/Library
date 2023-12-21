using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.GeekYaparApi.Categories
{
    public class CreateCategoriesRequest
    {
        public string name { get; set; }
        public DateTime CreatedOn { get; set; }
        public int status { get; set; }
    }
}
