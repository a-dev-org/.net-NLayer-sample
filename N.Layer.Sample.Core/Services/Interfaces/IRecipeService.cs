using N.Layer.Sample.Core.Dto;
using N.Layer.Sample.Core.Dto.Recipe;

namespace N.Layer.Sample.Core.Services.Interfaces;

public interface IRecipeService
{
    public Task<ResponseDto<RecipeListDto>> GetRecipesAsync(GetRecipesDto creatorId);
    public Task<ResponseDto<RecipeSummaryDto>> GetRecipeByIdAsync(BaseRecipeDto dto);
    public Task<ResponseDto<string?>> AddRecipeAsync(AddRecipeDto dto);
    public Task<ResponseDto<string?>> RemoveRecipeAsync(BaseRecipeDto dto);
    public Task<ResponseDto<string?>> UpdateRecipeAsync(UpdateRecipeDto dto);
}