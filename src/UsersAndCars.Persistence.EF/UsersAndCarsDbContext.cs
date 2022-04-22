using Microsoft.EntityFrameworkCore;

namespace UsersAndCars.Persistence.EF
{
    public class UsersAndCarsDbContext :DbContext
    {
        public UsersAndCarsDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder _)
        {
            _.ApplyConfigurationsFromAssembly
                (typeof(UsersAndCarsDbContext).Assembly);
            base.OnModelCreating(_);
        }
    }
}
