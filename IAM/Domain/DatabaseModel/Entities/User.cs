using Contract.Request.Roles;
using DatabaseModel.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public UserStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ISet<Role> Roles { get; set; }
    }
}
