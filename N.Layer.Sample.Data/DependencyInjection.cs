using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using N.Layer.Sample.Data.Repositories.EF;
using N.Layer.Sample.Data.Repositories.Interfaces;

namespace N.Layer.Sample.Data;

public static class DependencyInjection
{
    public static void AddDataDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<NLayerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies());

        services.AddScoped<IRecipeRepository, RecipeRepository>();
    }
}