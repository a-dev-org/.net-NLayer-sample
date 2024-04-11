using FluentValidation;

namespace N.Layer.Sample.Core.Dto.Recipe;

public record GetRecipesDto(Guid? Creator);

