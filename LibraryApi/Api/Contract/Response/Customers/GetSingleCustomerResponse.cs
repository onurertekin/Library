using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.Customers
{
    public class GetSingleCustomerResponse
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? identity { get; set; }
        public string? phoneNumber { get; set; }
        public int status { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
