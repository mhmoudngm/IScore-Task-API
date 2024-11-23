using Application.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Author.Create
{
    public class CreateNewAuthorCommandValidator : AbstractValidator<CreateNewAuthorCommand>
    {
        public CreateNewAuthorCommandValidator()
        {
            RuleFor(i => i.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithErrorCode(ValidationErrorCodes.Mandatory.ToString()).WithMessage(ValidationMessages.Madatory)
                .NotNull().WithErrorCode(ValidationErrorCodes.Mandatory.ToString()).WithMessage(ValidationMessages.Madatory);
        }
    }
}
