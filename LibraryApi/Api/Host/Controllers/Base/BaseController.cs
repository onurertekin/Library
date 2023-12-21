using DomainService.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        public void ValidateRequest<TRequest, TValidator>(TRequest request) where TValidator : AbstractValidator<TRequest>, new()
        {
            var validationResult = new TValidator().Validate(request);

            if (!validationResult.IsValid)
                throw new BusinessException(400, Newtonsoft.Json.JsonConvert.SerializeObject(validationResult.Errors.Select(e => e.ErrorMessage)));
        }
    }
}
