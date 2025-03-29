namespace NetSpeed.Evolution.Infrastructure.Persistence.Mappings;

public class SwotMapping : IEntityTypeConfiguration<Swot>
{
    public void Configure(EntityTypeBuilder<Swot> builder)
    {
        builder
            .ToTable("Swot")
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.EmployeeId)
            .IsRequired();

        builder
            .Property(x => x.CreatedById)
            .IsRequired();

        builder
            .Property(x => x.UpdatedById)
            .IsRequired(false);

        builder
            .Property(x => x.CreatedAt)
            .HasColumnType("datetime")
            .IsRequired();

        builder
            .Property(x => x.UpdatedAt)
            .HasColumnType("datetime")
            .IsRequired(false);

        builder
            .Property(x => x.Status)
            .HasColumnType("varchar(20)")
            .IsRequired()
            .HasConversion<string>();

        builder
            .Property(x => x.CycleId)
            .IsRequired();

        builder
            .HasIndex(x => new {x.Id, x.CycleId })
            .IsUnique()
            .HasDatabaseName("UK_Swot_Id_CycleId");

        #region Foreign key to table.

        builder
            .HasOne(s => s.Employee)
            .WithMany(e => e.Swots)
            .HasForeignKey(s => s.EmployeeId)
            .HasConstraintName("FK_Swot_Employee_EmployeeId")
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(s => s.CreatedBy)
            .WithMany(u => u.SwotsCreatedByUser)
            .HasForeignKey(s => s.CreatedById)
            .HasConstraintName("FK_Swot_User_CreatedById")
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(s => s.UpdatedBy)
            .WithMany(u => u.SwotsUpdatedByUser)
            .HasForeignKey(s => s.UpdatedById)
            .HasConstraintName("FK_Swot_User_UpdatedById")
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(s => s.Cycle)
            .WithMany(c => c.Swots)
            .HasForeignKey(s => s.CycleId)
            .HasConstraintName("FK_Swot_Cycle_CycleId")
            .OnDelete(DeleteBehavior.NoAction);

        #endregion
    }
}
