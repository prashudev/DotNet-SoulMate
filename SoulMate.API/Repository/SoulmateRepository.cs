using SoulMate.API.data;

namespace SoulMate.API.Repository
{
    public class SoulmateRepository : GenericRepository<Soulmate>, ISoulmateRepository
    {
        private readonly SoulmateDbContext _context;
        public SoulmateRepository(SoulmateDbContext _context) : base(_context)
        {
            this._context = _context;
        }

        public Task<Soulmate> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
