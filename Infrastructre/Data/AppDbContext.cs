using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructre.Data;

public class AppDbContext :DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
	{

	}

	public DbSet<Product> products { get; set; }

}
