
namespace FunTranslate.Persistence;
public class FunTranslateDbContext : DbContext
{
    public FunTranslateDbContext(DbContextOptions<FunTranslateDbContext> options) : base(options) { }

    public DbSet<FunTranslation> FunTranslates { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FunTranslateDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var e in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (e.State)
            {
                case EntityState.Modified:
                    e.Entity.LastModifiedDate = DateTime.Now;
                    break;
                case EntityState.Added:
                    e.Entity.CreatedDate = DateTime.Now;
                    break;
                default:
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
