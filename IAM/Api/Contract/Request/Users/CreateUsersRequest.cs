using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.Users
{
    public class CreateUsersRequest
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? userName { get; set; }
        public string? password { get; set; }
        public int status { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
