using Loading.DAL.Interfaces;
using Loading.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loading.Api.Controllers
{
    [ApiController]
    [Tags("Виды Участков (RegionTypes)")]
    [Route("api/regionTypes/")]
    public class RegionTypeController: ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public RegionTypeController(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        [HttpGet("")]
        public IActionResult GetAllRegionTypes()
        {
            return Ok(_repository.RegionTypes.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetRegionTypeById(int id)
        {
            RegionType? result = _repository.RegionTypes.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("add/{name}")]
        public IActionResult CreateRegionType(string name)
        {
            RegionType? regionTypeWithSameName = _repository.RegionTypes.GetByCondition(p => p.Name.Equals(name)).FirstOrDefault();

            if (regionTypeWithSameName != null)
                return BadRequest("RegionType with same name already exist");

            RegionType newRegionType = _repository.RegionTypes.Create(new RegionType() { Name = name });

            _repository.Save();

            return Ok(newRegionType.Id);
        }

        [HttpDelete("remove/{id}")]
        public IActionResult DeleteRegionType(int id)
        {
            RegionType? regionTypeToDelete = _repository.RegionTypes.GetById(id);

            if (regionTypeToDelete == null)
                return NotFound("RegionType with this id was not found");

            _repository.RegionTypes.Delete(regionTypeToDelete);

            _repository.Save();

            return Ok();
        }
    }
}
