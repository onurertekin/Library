using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.Authors
{
    public class UpdateAuthorRequest
    {
        public string name { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int status { get; set; }
    }
    public class UpdateAuthorRequestValidator : AbstractValidator<UpdateAuthorRequest>
    {
        public UpdateAuthorRequestValidator()
        {
            RuleFor(authors => authors.name).NotEmpty().WithMessage("Yazar adı boş olamaz.");
        }
    }
}
