namespace NetSpeed.Evolution.Infrastructure.Persistence.Mappings;

public class EmployeeMapping : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .ToTable("Employee")
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Name)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(x => x.RegistrationNumber)
            .HasColumnType("varchar(15)")
            .IsRequired();

        builder
            .Property(x => x.ManagerId)
            .IsRequired(false);

        builder
            .Property(x => x.JobTitleId)
            .IsRequired();

        builder
            .Property(x => x.DepartmentId)
            .IsRequired();

        builder
            .Property(x => x.IsDeleted)
            .HasColumnType("bit")
            .HasDefaultValueSql("0")
            .IsRequired();

        #region Foreign key to table.

        builder
            .HasOne(e => e.Manager)
            .WithMany(m => m.Subordinates)
            .HasForeignKey(e => e.ManagerId)
            .HasConstraintName("FK_Employee_Employee_ManagerId")
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(e => e.JobTitle)
            .WithMany(jt => jt.Employees)
            .HasForeignKey(e => e.JobTitleId)
            .HasConstraintName("FK_Employee_JobTitle_JobTitleId")
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .HasConstraintName("FK_Employee_Department_DepartmentId")
            .OnDelete(DeleteBehavior.NoAction);

        #endregion
    }
}
