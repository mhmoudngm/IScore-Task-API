using Application.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Books.Delete
{
    public class DeleteBookCommandValidator:AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(i => i.Id)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithErrorCode(ValidationErrorCodes.Mandatory.ToString()).WithMessage(ValidationMessages.Madatory)
            .NotNull().WithErrorCode(ValidationErrorCodes.Mandatory.ToString()).WithMessage(ValidationMessages.Madatory);
        }
    }
}
