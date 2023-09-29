using Loading.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loading.DAL.Repositories
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        AppDbContext _appDbContext;
        IEquipmentRepository _equipments;
        IManufacturerRepository _manufacturers;
        IPostRepository _posts;
        IRegionRepository _regions;
        IRegionTypeRepository _regionTypes;

        public IManufacturerRepository Manufacturers
        {
            get
            {
                if (_manufacturers == null)
                    _manufacturers = new ManufacturerRepository(_appDbContext);

                return _manufacturers;
            }
        }

        public IEquipmentRepository Equipments
        {
            get
            {
                if (_equipments == null)
                    _equipments = new EquipmentRepository(_appDbContext);

                return _equipments;
            }
        }

        public IRegionTypeRepository RegionTypes
        {
            get
            {
                if (_regionTypes == null)
                    _regionTypes = new RegionTypeRepository(_appDbContext);

                return _regionTypes;
            }
        }

        public IRegionRepository Regions
        {
            get
            {
                if (_regions == null)
                    _regions = new RegionRepository(_appDbContext);

                return _regions;
            }
        }

        public IPostRepository Posts
        {
            get
            {
                if (_posts == null)
                    _posts = new PostRepository(_appDbContext);

                return _posts;
            }
        }

        public RepositoryWrapper(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool DbStatus()
        {
            return _appDbContext.Database.CanConnect();
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
