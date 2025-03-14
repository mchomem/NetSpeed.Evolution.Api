﻿namespace NetSpeed.Evolution.Infrastructure.Persistence.Contexts;

public class AppDbContext : DbContext
{
    DbSet<JobTitle> JobTitle { get; set; }
    DbSet<Department> Department { get; set; }

    DbSet<HardSkill> HardSkill { get; set; }
    DbSet<Employee> Employee { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobTitleMapping).Assembly);
}
