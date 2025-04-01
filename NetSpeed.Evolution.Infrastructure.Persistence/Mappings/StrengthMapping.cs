namespace NetSpeed.Evolution.Infrastructure.Persistence.Mappings;

public class StrengthMapping : IEntityTypeConfiguration<Strength>
{
    public void Configure(EntityTypeBuilder<Strength> builder)
    {
        builder
            .ToTable("Strength")
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
            .HasOne(s => s.Swot)
            .WithMany(sw => sw.Strengths)
            .HasForeignKey(s => s.SwotId)
            .HasConstraintName("FK_Strength_Swot_SwotId")
            .OnDelete(DeleteBehavior.NoAction);

        #endregion
    }
}
