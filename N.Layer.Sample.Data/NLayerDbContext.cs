using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using N.Layer.Sample.Data.Entities;

namespace N.Layer.Sample.Data;

public class NLayerDbContext(DbContextOptions<NLayerDbContext> options) : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    public override DbSet<User> Users { get; set; } = null!;

    public DbSet<Recipe> Recipes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(NLayerDbContext).Assembly);
        base.OnModelCreating(builder);
    }
};