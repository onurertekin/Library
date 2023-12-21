using System;

namespace Contract.Response.IAM.User
{
    public class GetSingleUsersResponse
    {
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? userName { get; set; }
        public string? password { get; set; }
        public int status { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
