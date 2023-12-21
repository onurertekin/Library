using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.LibraryApi.Rezervation
{
    public class UpdateRezervationRequest
    {
        public string rezervationStartDate { get; set; }
        public string rezervationEndDate { get; set; }
        public int customerId { get; set; }
        public int bookId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int status { get; set; }
    }
}
