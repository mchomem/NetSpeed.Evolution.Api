namespace NetSpeed.Evolution.Infrastructure.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<JobTitle> JobTitle { get; set; }
    public DbSet<Department> Department { get; set; }
    public DbSet<HardSkill> HardSkill { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<EmployeeHardSkill> EmployeeHardSkill { get; set; }
    public DbSet<Swot> Swot { get; set; }
    public DbSet<Strength> Strength { get; set; }
    public DbSet<Opportunity> Opportunity { get; set; }
    public DbSet<Weakness> Weakness { get; set; }
    public DbSet<Threat> Threat { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Cycle> Cycle { get; set; }
    public DbSet<ActionPlain5W2H> ActionPlain5W2H { get; set; }
    public DbSet<ActionPlain5W2HFollowUp> ActionPlain5W2HFollowUp { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobTitleMapping).Assembly);
}
