using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersAndCars.Entities;

namespace UsersAndCars.Persistence.EF.Users
{
    public class UserEntityMap :IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(30);

            builder.Property(x => x.Family)
                .HasMaxLength(50);

            builder.Property(x => x.NationalCode)
                .HasMaxLength(10)
                .IsRequired();

            builder.HasMany(x => x.Plaques)
                .WithOne(x => x.Users)
                .HasForeignKey(x => x.UserId);
        }
    }
}
