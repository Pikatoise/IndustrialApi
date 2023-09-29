using Loading.Domain.Models;

namespace Loading.DAL.Interfaces
{
    public interface IManufacturerRepository: IBaseRepository<Manufacturer>
    {
        public Manufacturer? GetById(int id);
    }
}
