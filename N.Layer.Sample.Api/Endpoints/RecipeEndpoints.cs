using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using N.Layer.Sample.Core.Dto.Recipe;
using N.Layer.Sample.Core.Services.Interfaces;

namespace N.Layer.Sample.Api.Endpoints;

public static class RecipeEndpoints
{
    public static IEndpointRouteBuilder MapRecipeEndpoints(this IEndpointRouteBuilder builder)
    {
        RouteGroupBuilder group = builder.MapGroup("recipe");

        group.MapGet("", async (
                    [FromQuery] Guid? creatorId,
                    IRecipeService recipeService) =>
                Results.Json(await recipeService.GetRecipesAsync(new GetRecipesDto(creatorId))))
            .RequireAuthorization();

        group.MapGet("{id:int}", async (
            [FromRoute] int id,
            IRecipeService recipeService,
            IValidator<BaseRecipeDto> validator) =>
        {
            var dto = new BaseRecipeDto(id);
            await validator.ValidateAsync(dto);

            return Results.Json(await recipeService.GetRecipeByIdAsync(dto));
        }).RequireAuthorization();

        group.MapPost("", async (
            [FromBody] AddRecipeDto dto,
            IRecipeService recipeService,
            IValidator<AddRecipeDto> validator) =>
        {
            await validator.ValidateAsync(dto);

            return Results.Json(await recipeService.AddRecipeAsync(dto));
        }).RequireAuthorization();

        group.MapDelete("{id:int}", async (
            [FromRoute] int id,
            IRecipeService recipeService,
            IValidator<BaseRecipeDto> validator) =>
        {
            var dto = new BaseRecipeDto(id);
            await validator.ValidateAsync(dto);

            return Results.Json(await recipeService.RemoveRecipeAsync(dto));
        }).RequireAuthorization();

        group.MapPut("", async (
            [FromBody] UpdateRecipeDto dto,
            IRecipeService recipeService,
            IValidator<UpdateRecipeDto> validator) =>
        {
            await validator.ValidateAsync(dto);

            return Results.Json(await recipeService.UpdateRecipeAsync(dto));
        }).RequireAuthorization();

        return builder;
    }
}