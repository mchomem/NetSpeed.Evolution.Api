namespace NetSpeed.Evolution.Infrastructure.Persistence.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("User")
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Login)
            .HasColumnType("varchar(30)")
            .IsRequired();

        builder
            .HasIndex(x => x.Login)
            .IsUnique()
            .HasDatabaseName("UK_User_Login");

        builder
            .Property(x => x.Password)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(x => x.Blocked)
            .HasDefaultValueSql("0")
            .IsRequired();

        #region Foreign key to table.

        builder
            .HasOne(u => u.Employee)
            .WithOne(e => e.User)
            .HasForeignKey<Employee>(u => u.Id)
            .HasConstraintName("FK_User_Employee_Id")
            .OnDelete(DeleteBehavior.NoAction);

        #endregion
    }
}
