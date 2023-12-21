using Contract.Request.Books;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.Authors
{
    public class CreateAuthorRequest
    {
        public string name { get; set; }
        public DateTime CreatedOn { get; set; }
        public int status { get; set; }
    }

    public class CreateAuthorRequestValidator : AbstractValidator<CreateAuthorRequest>
    {
        public CreateAuthorRequestValidator()
        {
            RuleFor(authors => authors.name).NotEmpty().WithMessage("Yazar adı boş olamaz.");
        }
    }
}
