using Loading.Domain.Models;

namespace Loading.DAL.Interfaces
{
    public interface IEquipmentRepository: IBaseRepository<Equipment>
    {
        public Equipment? GetById(int id);
    }
}
