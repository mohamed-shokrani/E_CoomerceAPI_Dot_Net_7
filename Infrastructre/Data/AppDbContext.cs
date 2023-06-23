using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructre.Data;

public class AppDbContext :DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
	{

	}
	// this is the method that is responsible for creating that migration
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

	}
	public DbSet<Product> products { get; set; }
	public DbSet<ProductBrand> productBrands { get; set; }
	public DbSet<ProductType> productTypes { get; set; }

}
