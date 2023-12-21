using DatabaseModel.Enumerations;

namespace DatabaseModel.Entities
{
    public class Rezervation
    {
        public int Id { get; set; }
        public string RezervationStartDate { get; set; }
        public string RezervationEndDate { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public RezervationStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Book Book { get; set; }
    }
}
