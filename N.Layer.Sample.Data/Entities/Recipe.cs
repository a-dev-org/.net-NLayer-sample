namespace N.Layer.Sample.Data.Entities;

public class Recipe : BaseEntity
{
    public required string Name { get; set; }

    public required string ImageUrl { get; set; }

    public required string Description { get; set; }

    public bool IsModerated { get; set; }

    public Guid CreatorId { get; set; }

    public virtual User Creator { get; set; } = null!;

    public required decimal Calories { get; set; }
}