using Loading.DAL.Interfaces;
using Loading.Domain.Models;

namespace Loading.DAL.Repositories
{
    public class ManufacturerRepository: BaseRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public Manufacturer? GetById(int id) =>
            _appDbContext.Set<Manufacturer>().Where(x => x.Id == id).FirstOrDefault();
    }
}
