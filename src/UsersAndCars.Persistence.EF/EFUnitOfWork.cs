using UsersAndCars.Infrastructure.Application;

namespace UsersAndCars.Persistence.EF
{
    public class EFUnitOfWork : UnitOfWork
    {
        private readonly UsersAndCarsDbContext _context;

        public EFUnitOfWork(UsersAndCarsDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
