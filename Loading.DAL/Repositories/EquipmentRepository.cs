using Loading.DAL.Interfaces;
using Loading.Domain.Models;

namespace Loading.DAL.Repositories
{
    public class EquipmentRepository : BaseRepository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(AppDbContext appDbContext): base(appDbContext)
        {
            
        }

        public Equipment? GetById(int id) =>
            _appDbContext.Set<Equipment>().Where(x => x.Id == id).FirstOrDefault();
    }
}
