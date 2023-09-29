using Loading.DAL.Interfaces;
using Loading.Domain.Models;

namespace Loading.DAL.Repositories
{
    public class RegionRepository: BaseRepository<Region>, IRegionRepository
    {
        public RegionRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public Region? GetByCode(string code) =>
            _appDbContext.Set<Region>().Where(x => x.Code.Equals(code)).FirstOrDefault();
    }
}
