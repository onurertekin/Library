using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.Books
{
    public class UpdateBookRequest
    {
        public string? name { get; set; }
        public int pageCount { get; set; }
        public int isbn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int status { get; set; }

    }
    public class UpdateBookRequestValidator : AbstractValidator<UpdateBookRequest>
    {
        public UpdateBookRequestValidator()
        {
            RuleFor(book => book.name).NotEmpty().WithMessage("Kitap adı boş olamaz.");
            RuleFor(book => book.pageCount).GreaterThan(0).WithMessage("Sayfa sayısı 0'dan büyük olmalıdır");
            RuleFor(book => book.isbn).NotEmpty().WithMessage("Isbn boş olamaz");
        }
    }
}
