using N.Layer.Sample.Data.Entities;
using N.Layer.Sample.Data.Repositories.Interfaces;

namespace N.Layer.Sample.Data.Repositories.EF;

public class RecipeRepository(NLayerDbContext context) : BaseRepository<Recipe>(context), IRecipeRepository;