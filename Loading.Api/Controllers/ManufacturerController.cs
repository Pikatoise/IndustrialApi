using Loading.DAL.Interfaces;
using Loading.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loading.Api.Controllers
{
    [ApiController]
    [Tags("Производители (Manufacturers)")]
    [Route("api/manufacturers/")]
    public class ManufacturerController: ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public ManufacturerController(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        [HttpGet("")]
        public IActionResult GetAllManufacturers()
        {
            return Ok(_repository.Manufacturers.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetManufacturerById(int id)
        {
            Manufacturer? result = _repository.Manufacturers.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("add/{name}")]
        public IActionResult CreateManufacturer(string name)
        {
            Manufacturer? manufacturerWithSameName = _repository.Manufacturers.GetByCondition(p => p.Name.Equals(name)).FirstOrDefault();

            if (manufacturerWithSameName != null)
                return BadRequest("Manufacturer with same name already exist");

            Manufacturer newManufacturer = _repository.Manufacturers.Create(new Manufacturer() { Name = name });

            _repository.Save();

            return Ok(newManufacturer.Id);
        }

        [HttpPut("change/id={id}&name={name}")]
        public IActionResult ChangeManufacturerName(int id, string name)
        {
            var manufacturer = _repository.Manufacturers.GetById(id);

            if (manufacturer == null)
                return NotFound("Manufacturer with this id not exist");

            manufacturer.Name = name;

            _repository.Manufacturers.Update(manufacturer);

            _repository.Save();

            return Ok();
        }

        [HttpDelete("remove/{id}")]
        public IActionResult DeleteManufacturer(int id)
        {
            Manufacturer? manufacturerToDelete = _repository.Manufacturers.GetById(id);

            if (manufacturerToDelete == null)
                return NotFound("Manufacturer with this id was not found");

            _repository.Manufacturers.Delete(manufacturerToDelete);

            _repository.Save();

            return Ok();
        }
    }
}
