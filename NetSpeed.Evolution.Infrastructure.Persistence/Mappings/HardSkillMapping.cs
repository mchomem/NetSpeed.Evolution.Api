namespace NetSpeed.Evolution.Infrastructure.Persistence.Mappings;

public class HardSkillMapping : IEntityTypeConfiguration<HardSkill>
{
    public void Configure(EntityTypeBuilder<HardSkill> builder)
    {
        builder
            .ToTable("HardSkill")
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Name)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(x => x.IsDeleted)
            .HasColumnType("bit")
            .HasDefaultValueSql("0")
            .IsRequired();

        builder
            .HasIndex(x => x.Name)
            .IsUnique()
            .HasDatabaseName("UK_HardSkill_Name");
    }
}
