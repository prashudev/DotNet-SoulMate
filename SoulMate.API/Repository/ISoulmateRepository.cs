using SoulMate.API.data;

namespace SoulMate.API.Repository
{
    public interface ISoulmateRepository : IGenericRepository<Soulmate>
    {
        Task<Soulmate> GetById(int id);
    }
}
