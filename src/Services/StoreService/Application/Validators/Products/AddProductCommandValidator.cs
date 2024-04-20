using FluentValidation;
using StoreService.Application.Models.Commands.Products;
using StoreService.Domain;

namespace StoreService.Application.Validators.Products
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            // Title
            RuleFor(x => x.Title)
                .MaximumLength(Defaults.TitleLength)
                .WithState(_ => Errors.Errors.InvalidTitleValidationError);
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithState(_ => Errors.Errors.InvalidTitleValidationError);
        }
    }
}
