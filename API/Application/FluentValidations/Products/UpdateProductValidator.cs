using API.Application.Requests.Products;
using FluentValidation;
using static API.Application.Constants.ProductMessage;

namespace API.Application.FluentValidations.Products
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(NameRequired)
                .MaximumLength(100)
                .WithMessage(NameMaxLength);
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage(DescriptionRequired)
                .MaximumLength(255)
                .WithMessage(DescriptionMaxLength);
            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage(PriceRequired)
                .GreaterThan(0)
                .WithMessage(PriceGreaterThanZero);
        }
    }
}
