using FluentValidation;

namespace N.Layer.Sample.Core.Dto.Recipe;

public record UpdateRecipeDto(
    int Id,
    string Name,
    string ImageUrl,
    string Description,
    decimal Calories,
    bool IsModerated);

public class UpdateRecipeDtoValidator : ApplicationAbstractValidator<UpdateRecipeDto>
{
    public UpdateRecipeDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.ImageUrl).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Calories).NotNull().GreaterThan(0);
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
        RuleFor(x => x.IsModerated).NotNull();
    }
}