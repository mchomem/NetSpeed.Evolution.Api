namespace NetSpeed.Evolution.Infrastructure.Persistence.Mappings;

public class ThreatMapping : IEntityTypeConfiguration<Threat>
{
    public void Configure(EntityTypeBuilder<Threat> builder)
    {
        builder
            .ToTable("Threat")
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Description)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(x => x.Order)
            .IsRequired();

        #region Foreign key to table.

        builder
            .HasOne(t => t.Swot)
            .WithMany(sw => sw.Threats)
            .HasForeignKey(t => t.SwotId)
            .HasConstraintName("FK_Threat_Swot_SwotId")
            .OnDelete(DeleteBehavior.NoAction);

        #endregion
    }
}
