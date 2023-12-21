using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.Categories
{
    public class UpdateCategoriesRequest
    {
        public string name { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int status { get; set; }
    }
    public class UpdateCategoriesRequestValidator : AbstractValidator<UpdateCategoriesRequest>
    {
        public UpdateCategoriesRequestValidator()
        {
            RuleFor(categories => categories.name).NotEmpty().WithMessage("Kategori adı boş olamaz.");
        }
    }
}
