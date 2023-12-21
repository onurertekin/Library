using System;
using System.Collections.Generic;

namespace Contract.Response.IAM.Role
{
    public class SearchRolesResponse
    {
        public class Role
        {
            public int id { get; set; }
            public string name { get; set; }
            public int status { get; set; }
            public DateTime CreatedOn { get; set; }
            public DateTime? UpdatedOn { get; set; }
        }
        public SearchRolesResponse()
        {
            roles = new List<Role>();
        }
        public List<Role> roles { get; set; }
        public int totalCount { get; set; }

    }
}
