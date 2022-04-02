using Feetur.Shared.Models;
using FluentValidation;

namespace Feetur.Api.Validators;

public class FeatureValidator: AbstractValidator<Feature>
{
    public FeatureValidator()
    {
        RuleFor(f => f).NotNull().WithMessage("Feature should not be null.");
        RuleFor(f => f.Name).NotEmpty().WithMessage("Feature name should not be empty.");
    }
}