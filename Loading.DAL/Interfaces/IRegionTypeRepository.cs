﻿using Loading.Domain.Models;

namespace Loading.DAL.Interfaces
{
    public interface IRegionTypeRepository: IBaseRepository<RegionType>
    {
        public RegionType? GetById(int id);
    }
}
