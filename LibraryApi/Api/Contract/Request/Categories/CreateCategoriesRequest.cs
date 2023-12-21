using Contract.Request.Authors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.Categories
{
    public class CreateCategoriesRequest
    {
        public string name { get; set; }
        public DateTime CreatedOn { get; set; }
        public int status { get; set; }
    }
    public class CreateCategoriesRequestValidator : AbstractValidator<CreateCategoriesRequest>
    {
        public CreateCategoriesRequestValidator()
        {
            RuleFor(categories => categories.name).NotEmpty().WithMessage("Kategori adı boş olamaz.");
        }
    }
}
