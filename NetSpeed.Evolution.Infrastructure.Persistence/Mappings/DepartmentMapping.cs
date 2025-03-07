namespace NetSpeed.Evolution.Infrastructure.Persistence.Mappings;

public class DepartmentMapping : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder
            .ToTable("Department")
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Name)
            .HasColumnType("varchar(30)")
            .IsRequired();

        builder
            .Property(x => x.IsDeleted)
            .HasColumnType("bit")
            .HasDefaultValueSql("0")
            .IsRequired();
    }
}
