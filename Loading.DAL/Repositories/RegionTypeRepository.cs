using Loading.DAL.Interfaces;
using Loading.Domain.Models;

namespace Loading.DAL.Repositories
{
    public class RegionTypeRepository: BaseRepository<RegionType>, IRegionTypeRepository
    {
        public RegionTypeRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public RegionType? GetById(int id) =>
            _appDbContext.Set<RegionType>().Where(x => x.Id == id).FirstOrDefault();
    }
}
