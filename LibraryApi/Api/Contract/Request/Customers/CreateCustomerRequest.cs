using Contract.Request.Books;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.Customers
{
    public class CreateCustomerRequest
    {
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? identity { get; set; }
        public string? phoneNumber { get; set; }
        public int status { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(customers => customers.name).NotEmpty().WithMessage("Müşteri adı boş olamaz.");
            RuleFor(customers => customers.surname).NotEmpty().WithMessage("Müşteri soyadı boş olamaz");

            RuleFor(customers => customers.identity)
                .NotEmpty().WithMessage("TC kimlik numarası boş olamaz.")
                .Length(11).WithMessage("TC kimlik numarası 11 haneli olmalıdır.")
                .Matches(@"^\d{11}$").WithMessage("Geçersiz TC kimlik numarası formatı.");

            RuleFor(customers => customers.phoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz")
                .Matches(@"^\d{10}$").WithMessage("Geçersiz telefon numarası formatı.");
        }
    }
}
