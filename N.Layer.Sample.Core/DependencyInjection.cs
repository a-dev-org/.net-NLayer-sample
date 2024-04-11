using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using N.Layer.Sample.Core.Dto.Recipe;
using N.Layer.Sample.Core.Services;
using N.Layer.Sample.Core.Services.Interfaces;
using N.Layer.Sample.Data;

namespace N.Layer.Sample.Core;

public static class DependencyInjection
{
    public static void AddCoreDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataDependencies(configuration);

        ValidatorOptions.Global.LanguageManager.Enabled = false;
        services.AddValidatorsFromAssemblyContaining<GetRecipesDto>();
        
        
        services.AddScoped<IRecipeService, RecipeService>();
    }
}