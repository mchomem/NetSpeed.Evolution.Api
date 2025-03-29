namespace NetSpeed.Evolution.Infrastructure.Persistence.Mappings;

public class CycleMapping : IEntityTypeConfiguration<Cycle>
{
    public void Configure(EntityTypeBuilder<Cycle> builder)
    {
        builder
            .ToTable("Cycle")
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Year)
            .IsRequired();

        builder
            .HasIndex(x => x.Year)
            .IsUnique()
            .HasDatabaseName("UK_Cycle_Year");

        builder
            .Property(x => x.Active)
            .HasDefaultValueSql("0")
            .IsRequired();

        builder
            .Property(x => x.CreatedAt)
            .HasColumnType("datetime")
            .IsRequired();

        builder
            .Property(x => x.UpdatedAt)
            .HasColumnType("datetime")
            .IsRequired(false);
    }
}
