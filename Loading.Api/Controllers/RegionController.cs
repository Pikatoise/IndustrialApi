using Loading.Api.DTO;
using Loading.DAL.Interfaces;
using Loading.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loading.Api.Controllers
{
    [ApiController]
    [Tags("Участки (Regions)")]
    [Route("api/regions/")]
    public class RegionController: ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public RegionController(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        [HttpGet("")]
        public IActionResult GetAllRegions()
        {
            return Ok(_repository.Regions.GetAll());
        }

        [HttpGet("{code}")]
        public IActionResult GetRegionByCode(string code)
        {
            Region? result = _repository.Regions.GetByCode(code);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("regionType/{id}")]
        public IActionResult GetRegionsByRegionTypeId(int id)
        {
            RegionType? regionType = _repository.RegionTypes.GetById(id);

            if (regionType == null)
                return NotFound("RegionType with this id not exist");

            return Ok(_repository.Regions.GetByCondition(e => e.RegionTypeId == id));
        }

        [HttpPost("add")]
        public IActionResult CreateRegion([FromBody] CreateRegionData createRegionData)
        {
            if (_repository.Regions.GetByCondition(r => r.Code.Equals(createRegionData.Code)).FirstOrDefault() != null)
                return BadRequest("This code is already exist");

            Region newRegion = new Region() 
            { 
                Code = createRegionData.Code,
                Name = createRegionData.Name
            };

            RegionType? regionType = _repository.RegionTypes.GetById(createRegionData.RegionTypeId);

            if (regionType == null)
                return BadRequest("RegionType is not exist");

            newRegion.RegionType = regionType;

            newRegion = _repository.Regions.Create(newRegion);

            _repository.Save();

            return Ok(newRegion.Code);
        }

        [HttpPut("change")]
        public IActionResult ChangeRegion([FromBody] ChangeRegionData changeRegionData)
        {
            var region = _repository.Regions.GetByCode(changeRegionData.Code);

            if (region == null)
                return NotFound("Region with this id not exist");

            if (changeRegionData.Name != null)
                region.Name = changeRegionData.Name;

            if (changeRegionData.RegionTypeId != null)
            {
                var regionType = _repository.RegionTypes.GetById((int)changeRegionData.RegionTypeId);

                if (regionType != null)
                    region.RegionTypeId = (int)changeRegionData.RegionTypeId;
            }

            _repository.Regions.Update(region);

            _repository.Save();

            return Ok();
        }

        [HttpDelete("remove/{code}")]
        public IActionResult DeleteRegion(string code)
        {
            Region? regionToDelete = _repository.Regions.GetByCode(code);

            if (regionToDelete == null)
                return NotFound("Region with this code was not found");

            _repository.Regions.Delete(regionToDelete);

            _repository.Save();

            return Ok();
        }
    }
}
