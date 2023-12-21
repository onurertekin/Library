using FluentValidation;

namespace Contract.Request.Books
{
    public class CreateBookRequest
    {
        public string? name { get; set; }
        public int pageCount { get; set; }
        public int isbn { get; set; }
        public DateTime CreatedOn { get; set; }
        public int status { get; set; }
    }

    public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
    {
        public CreateBookRequestValidator()
        {
            RuleFor(book => book.name).NotEmpty().WithMessage("Kitap adı boş olamaz.");
            RuleFor(book => book.pageCount).GreaterThan(0).WithMessage("Sayfa sayısı 0'dan büyük olmalıdır");
            RuleFor(book => book.isbn).NotEmpty().WithMessage("Isbn boş olamaz");
        }
    }
}
