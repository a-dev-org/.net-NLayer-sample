using FluentValidation;

namespace N.Layer.Sample.Core.Dto.Recipe;

public record BaseRecipeDto(int Id);

public class BaseRecipeDtoValidator : ApplicationAbstractValidator<BaseRecipeDto>
{
    public BaseRecipeDtoValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
    }
}