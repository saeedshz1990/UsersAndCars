using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersAndCars.Entities;

namespace UsersAndCars.Persistence.EF.Plaques
{
    public class PlaqueEntityMap :IEntityTypeConfiguration<Plaque>
    {
        public void Configure(EntityTypeBuilder<Plaque> builder)
        {
            builder.ToTable("Plagues");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.LeftNum)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(x => x.Letter)
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(x => x.RightNum)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(x => x.CityNum)
                .HasMaxLength(2)
                .IsRequired();

            builder.HasOne(x => x.Users)
                .WithMany(x => x.Plaques)
                .HasForeignKey(x => x.UserId);
        }
    }
}
