namespace NetSpeed.Evolution.Infrastructure.Persistence.Mappings;

public class ActionPlain5W2HMapping : IEntityTypeConfiguration<ActionPlain5W2H>
{
    public void Configure(EntityTypeBuilder<ActionPlain5W2H> builder)
    {
        builder
            .ToTable("ActionPlain5W2H")
            .HasKey(x => x.Id);

        builder
            .Property(x => x.EmployeeId)
            .IsRequired();

        builder
            .Property(x => x.CycleId)
            .IsRequired();

        builder
            .Property(x => x.ImprovementPoint)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(x => x.What)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(x => x.Who)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(x => x.Why)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(x => x.Where)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(x => x.When)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(x => x.How)
            .HasColumnType("varchar(200)")
            .IsRequired();

        builder
            .Property(x => x.HowMuch)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(x => x.Observation)
            .HasColumnType("varchar(1000)")
            .IsRequired();

        builder
            .Property(x => x.CreatedAt)
            .HasColumnType("datetime")
            .IsRequired();

        builder
            .Property(x => x.UpdatedAt)
            .HasColumnType("datetime")
            .IsRequired(false);

        #region Foreign key to table.

        builder
            .HasOne(ap => ap.Employee)
            .WithMany(e => e.ActionPlains5W2H)
            .HasForeignKey(ap => ap.EmployeeId)
            .HasConstraintName("FK_ActionPlain5W2H_Employee_EmployeeId")
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(ap => ap.Cycle)
            .WithMany(c => c.ActionPlains5W2H)
            .HasForeignKey(ap => ap.CycleId)
            .HasConstraintName("FK_ActionPlain5W2H_Cycle_CycleId")
            .OnDelete(DeleteBehavior.NoAction);

        #endregion
    }
}
