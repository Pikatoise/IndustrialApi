namespace Loading.DAL.Interfaces
{
    public interface IRepositoryWrapper
    {
        IManufacturerRepository Manufacturers { get; }
        IEquipmentRepository Equipments { get; }
        IRegionTypeRepository RegionTypes { get; }
        IRegionRepository Regions { get; }
        IPostRepository Posts { get; }
        void Save();
        bool DbStatus();
    }
}
