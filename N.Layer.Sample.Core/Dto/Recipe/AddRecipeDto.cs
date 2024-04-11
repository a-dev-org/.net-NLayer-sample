using FluentValidation;

namespace N.Layer.Sample.Core.Dto.Recipe;

public record AddRecipeDto(
    string Name,
    string ImageUrl,
    string Description,
    Guid CreatorId,
    decimal Calories);

public class AddRecipeDtoValidator : ApplicationAbstractValidator<AddRecipeDto>
{
    public AddRecipeDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.ImageUrl).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.CreatorId).NotEmpty();
        RuleFor(x => x.Calories).NotNull().GreaterThan(0);
    }
}