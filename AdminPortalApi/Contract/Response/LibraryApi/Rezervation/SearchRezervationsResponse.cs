using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.LibraryApi.Rezervation
{
    public class SearchRezervationsResponse
    {
        public class Rezervation
        {
            public int id { get; set; }
            public string rezervationStartDate { get; set; }
            public string rezervationEndDate { get; set; }
            public int customerId { get; set; }
            public int bookId { get; set; }
            public string customerName { get; set; }
            public string bookName { get; set; }
            public DateTime CreatedOn { get; set; }
            public DateTime? UpdatedOn { get; set; }
            public int status { get; set; }
        }
        public SearchRezervationsResponse()
        {
            rezervations = new List<Rezervation>();
        }
        public List<Rezervation> rezervations { get; set; }
        public int totalCount { get; set; }
    }
}
