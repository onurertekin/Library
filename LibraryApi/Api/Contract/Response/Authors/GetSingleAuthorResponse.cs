using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.Authors
{
    public class GetSingleAuthorResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int status { get; set; }
    }
}
