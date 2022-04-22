using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersAndCars.Entities;

namespace UsersAndCars.Persistence.EF.Cars
{
    public class CarEntityMap :IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");

            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(_ => _.Model)
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(_ => _.Color)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(_ => _.EngNumber)
                .IsRequired();

            builder.Property(_=> _.ChassisNumber)
                .IsRequired();

            builder.HasOne(x => x.Plaque)
                .WithOne(x => x.Car)
                .HasForeignKey<Plaque>(x => x.CarId);
        }
    }
}
