using DatabaseModel.Enumerations;

namespace DatabaseModel.Entities
{
    public class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
            Categories = new HashSet<Category>();
            Rezervations = new HashSet<Rezervation>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public int Isbn { get; set; }
        public BookStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ISet<Author> Authors { get; set; }
        public virtual ISet<Category> Categories { get; set; }
        public virtual ISet<Rezervation> Rezervations { get; set; }

    }
}
