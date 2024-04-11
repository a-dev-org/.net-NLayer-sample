using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using N.Layer.Sample.Core.Dto;
using N.Layer.Sample.Core.Dto.Recipe;
using N.Layer.Sample.Core.Services.Interfaces;
using N.Layer.Sample.Data.Entities;
using N.Layer.Sample.Data.Repositories.Interfaces;
using N.Layer.Sample.Shared.Constants;
using N.Layer.Sample.Shared.Exceptions;

namespace N.Layer.Sample.Core.Services;

public class RecipeService(IRecipeRepository recipeRepository)
    : IRecipeService
{
    public async Task<ResponseDto<RecipeListDto>> GetRecipesAsync(GetRecipesDto dto)
    {
        var recipeList = await recipeRepository.GetManyAsync(x => x.IsModerated && (dto.Creator == null || x.CreatorId == dto.Creator));

        var recipeListDto = recipeList.Select(x => new RecipeSummaryDto(x.Id, x.Name, x.Calories)).ToList();

        return new ResponseDto<RecipeListDto>(new RecipeListDto(recipeListDto), true, HttpStatusCode.OK);
    }

    public async Task<ResponseDto<RecipeSummaryDto>> GetRecipeByIdAsync(BaseRecipeDto dto)
    {
        var recipe = await recipeRepository.GetByIdAsync(dto.Id)
                     ?? throw new ApiException(string.Format(Errors.GenericNotFound, nameof(Recipe)));


        return new ResponseDto<RecipeSummaryDto>(
            new RecipeSummaryDto(recipe.Id, recipe.Name, recipe.Calories),
            true,
            HttpStatusCode.OK);
    }

    public async Task<ResponseDto<string?>> AddRecipeAsync(AddRecipeDto dto)
    {
        var recipe = new Recipe
        {
            Calories = dto.Calories,
            Description = dto.Description,
            Name = dto.Name,
            ImageUrl = dto.ImageUrl,
            CreatorId = dto.CreatorId,
            IsModerated = false
        };

        await recipeRepository.AddAsync(recipe);
        await recipeRepository.CommitChangesAsync();

        return new ResponseDto<string?>(null, true, HttpStatusCode.OK);
    }

    public async Task<ResponseDto<string?>> RemoveRecipeAsync(BaseRecipeDto dto)
    {
        var recipe = await recipeRepository.GetByIdAsync(dto.Id)
                     ?? throw new ApiException(string.Format(Errors.GenericNotFound, nameof(Recipe)));

        recipeRepository.Remove(recipe);
        await recipeRepository.CommitChangesAsync();

        return new ResponseDto<string?>(null, true, HttpStatusCode.OK);
    }

    public async Task<ResponseDto<string?>> UpdateRecipeAsync(UpdateRecipeDto dto)
    {
        var recipe = await recipeRepository.GetByIdAsync(dto.Id)
                     ?? throw new ApiException(string.Format(Errors.GenericNotFound, nameof(Recipe)));

        recipe.Description = dto.Description;
        recipe.Calories = dto.Calories;
        recipe.IsModerated = dto.IsModerated;
        recipe.ImageUrl = dto.ImageUrl;
        recipe.Name = dto.Name;

        await recipeRepository.CommitChangesAsync();

        return new ResponseDto<string?>(null, true, HttpStatusCode.OK);
    }
}