using DatabaseModel.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public AuthorStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ISet<Book> Books { get; set; }
    }
}
