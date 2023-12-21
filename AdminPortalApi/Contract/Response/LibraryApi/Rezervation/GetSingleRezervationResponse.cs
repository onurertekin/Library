using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.LibraryApi.Rezervation
{
    public class GetSingleRezervationResponse
    {
        public int id { get; set; }
        public string rezervationStartDate { get; set; }
        public string rezervationEndDate { get; set; }
        public int customerId { get; set; }
        public int bookId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int status { get; set; }
    }
}
