namespace NetSpeed.Evolution.Infrastructure.Persistence.Mappings;

public class WeaknessMapping : IEntityTypeConfiguration<Weakness>
{
    public void Configure(EntityTypeBuilder<Weakness> builder)
    {
        builder
            .ToTable("Weakness")
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
            .HasOne(w => w.Swot)
            .WithMany(sw => sw.Weaknesses)
            .HasForeignKey(w => w.SwotId)
            .HasConstraintName("FK_Weakness_Swot_SwotId")
            .OnDelete(DeleteBehavior.NoAction);

        #endregion
    }
}
