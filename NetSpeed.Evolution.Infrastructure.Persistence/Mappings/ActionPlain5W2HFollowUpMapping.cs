using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace NetSpeed.Evolution.Infrastructure.Persistence.Mappings;

public class ActionPlain5W2HFollowUpMapping : IEntityTypeConfiguration<ActionPlain5W2HFollowUp>
{
    public void Configure(EntityTypeBuilder<ActionPlain5W2HFollowUp> builder)
    {
        builder
            .ToTable("ActionPlain5W2HFollowUp")
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.ActionPlain5W2HId)
            .IsRequired();

        builder
            .Property(x => x.Annotation)
            .HasColumnType("varchar(1000)")
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

        #region Foreign key to table.

        builder
            .HasOne(apf => apf.ActionPlain5W2H)
            .WithMany(ap => ap.ActionPlain5W2HFollowUps)
            .HasForeignKey(apf => apf.ActionPlain5W2HId)
            .HasConstraintName("FK_ActionPlain5W2HFollowUp_ActionPlain5W2H_ActionPlain5W2HId")
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(apf => apf.CreatedBy)
            .WithMany(u => u.ActionPlain5W2HFollowUpCreatedByUser)
            .HasForeignKey(apf => apf.CreatedById)
            .HasConstraintName("FK_ActionPlain5W2HFollowUp_User_CreatedById")
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(apf => apf.UpdatedBy)
            .WithMany(u => u.ActionPlain5W2HFollowUpUpdatedByUser)
            .HasForeignKey(apf => apf.UpdatedById)
            .HasConstraintName("FK_ActionPlain5W2HFollowUp_User_UpdatedById")
            .OnDelete(DeleteBehavior.NoAction);

        #endregion
    }
}
