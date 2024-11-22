using Application.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Books.Create
{
    public class CreateNewBookCommandValidator : AbstractValidator<CreateNewBookCommand>
    {
        public CreateNewBookCommandValidator()
        {
            RuleFor(i => i.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithErrorCode(ValidationErrorCodes.Mandatory.ToString()).WithMessage(ValidationMessages.Madatory)
                .NotNull().WithErrorCode(ValidationErrorCodes.Mandatory.ToString()).WithMessage(ValidationMessages.Madatory);

            RuleFor(i => i.Description)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithErrorCode(ValidationErrorCodes.Mandatory.ToString()).WithMessage(ValidationMessages.Madatory)
                .NotNull().WithErrorCode(ValidationErrorCodes.Mandatory.ToString()).WithMessage(ValidationMessages.Madatory);

            RuleFor(i => i.PublishedDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithErrorCode(ValidationErrorCodes.Mandatory.ToString()).WithMessage(ValidationMessages.Madatory)
                .NotNull().WithErrorCode(ValidationErrorCodes.Mandatory.ToString()).WithMessage(ValidationMessages.Madatory);

            RuleFor(i => i.Quantity)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithErrorCode(ValidationErrorCodes.Mandatory.ToString()).WithMessage(ValidationMessages.Madatory)
                .NotNull().WithErrorCode(ValidationErrorCodes.Mandatory.ToString()).WithMessage(ValidationMessages.Madatory);

            RuleFor(i => i.AuthorId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithErrorCode(ValidationErrorCodes.Mandatory.ToString()).WithMessage(ValidationMessages.Madatory)
                .NotNull().WithErrorCode(ValidationErrorCodes.Mandatory.ToString()).WithMessage(ValidationMessages.Madatory);
        }
    }
}
