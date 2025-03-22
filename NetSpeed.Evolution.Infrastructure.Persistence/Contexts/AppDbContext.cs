namespace NetSpeed.Evolution.Infrastructure.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<JobTitle> JobTitle { get; set; }
    public DbSet<Department> Department { get; set; }
    public DbSet<HardSkill> HardSkill { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<EmployeeHardSkill> EmployeeHardSkill { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobTitleMapping).Assembly);
}
