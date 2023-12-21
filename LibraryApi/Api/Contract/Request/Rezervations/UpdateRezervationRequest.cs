using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.Rezervations
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
    public class UpdateRezervationRequestValidator : AbstractValidator<UpdateRezervationRequest>
    {
        public UpdateRezervationRequestValidator()
        {
            RuleFor(rezervations => rezervations.rezervationStartDate).NotEmpty().WithMessage("Rezervasyon başlangıç tarihi boş olamaz.");
            RuleFor(rezervations => rezervations.rezervationEndDate).NotEmpty().WithMessage("Rezervasyon bitiş tarihi boş olamaz");
            RuleFor(rezervations => rezervations.customerId).NotEmpty().WithMessage("CustomerId boş olamaz.");
            RuleFor(rezervations => rezervations.bookId).NotEmpty().WithMessage("BookId boş olamaz");

        }
    }
}
