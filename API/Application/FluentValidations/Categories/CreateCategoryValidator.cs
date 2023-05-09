﻿using API.Application.Requests.Categories;
using FluentValidation;
using static API.Application.Constants.CategoryMessage;

namespace API.Application.FluentValidations.Categories
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CreateCategoryValidator()
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

        }
    }
}
