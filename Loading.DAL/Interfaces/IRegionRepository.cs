﻿using Loading.Domain.Models;

namespace Loading.DAL.Interfaces
{
    public interface IRegionRepository: IBaseRepository<Region>
    {
        public Region? GetByCode(string code);
    }
}
