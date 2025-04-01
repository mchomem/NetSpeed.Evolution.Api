namespace NetSpeed.Evolution.Infrastructure.Persistence.Mappings;

public class OpportunityMapping : IEntityTypeConfiguration<Opportunity>
{
    public void Configure(EntityTypeBuilder<Opportunity> builder)
    {
        builder
            .ToTable("Opportunity")
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
            .HasOne(o => o.Swot)
            .WithMany(sw => sw.Opportunities)
            .HasForeignKey(o => o.SwotId)
            .HasConstraintName("FK_Opportunity_Swot_SwotId")
            .OnDelete(DeleteBehavior.NoAction);

        #endregion
    }
}
