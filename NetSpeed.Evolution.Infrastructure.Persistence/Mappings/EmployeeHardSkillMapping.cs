namespace NetSpeed.Evolution.Infrastructure.Persistence.Mappings;

public class EmployeeHardSkillMapping : IEntityTypeConfiguration<EmployeeHardSkill>
{
    public void Configure(EntityTypeBuilder<EmployeeHardSkill> builder)
    {
        builder
            .ToTable("EmployeeHardSkills")
            .HasKey(x => new { x.EmployeeId, x.HardSkillId });

        builder
            .Property(x => x.EmployeeId)
            .HasColumnType("bigint")
            .IsRequired();

        builder
            .Property(x => x.HardSkillId)
            .HasColumnType("bigint")
            .IsRequired();

        builder
            .Property(x => x.Level)
            .HasColumnType("varchar(15)")
            .IsRequired()
            .HasConversion<string>();

        #region Foreign key to table.

        builder
            .HasOne(eh => eh.Employee)
            .WithMany(e => e.EmployeeHardSkills)
            .HasForeignKey(eh => eh.EmployeeId)
            .HasConstraintName("FK_EmployeeHardSkills_Employee_EmployeeId")
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(eh => eh.HardSkill)
            .WithMany(hs => hs.EmployeeHardSkills)
            .HasForeignKey(eh => eh.HardSkillId)
            .HasConstraintName("FK_EmployeeHardSkills_HardSkill_HardSkillId")
            .OnDelete(DeleteBehavior.NoAction);

        #endregion
    }
}
