namespace NetSpeed.Evolution.Infrastructure.Persistence.Mappings;

public class JobTitleMapping : IEntityTypeConfiguration<JobTitle>
{
    public void Configure(EntityTypeBuilder<JobTitle> builder)
    {
        builder
            .ToTable("JobTitle")
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

        builder
            .HasIndex(x => x.Name)
            .IsUnique()
            .HasDatabaseName("UK_JobTitle_Name");
    }
}
