using DatabaseModel.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities
{
    public class Customer
    {
        public Customer()
        {
            Rezervations = new HashSet<Rezervation>();
        }
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(11)]
        public string Identity { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }
        public CustomerStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ISet<Rezervation> Rezervations { get; set; }

    }
}
