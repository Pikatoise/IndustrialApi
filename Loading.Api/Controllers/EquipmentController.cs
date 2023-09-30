using Loading.Api.DTO;
using Loading.DAL.Interfaces;
using Loading.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loading.Api.Controllers
{
    [ApiController]
    [Tags("Оборудование (Equipments)")]
    [Route("api/equipments/")]
    public class EquipmentController: ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public EquipmentController(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        [HttpGet("")]
        public IActionResult GetAllEquipments()
        {
            return Ok(_repository.Equipments.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetEquipmentById(int id)
        {
            Equipment? result = _repository.Equipments.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("manufacturer/{id}")]
        public IActionResult GetEquipmentsByManufacturerId(int id)
        {
            Manufacturer? manufacturer = _repository.Manufacturers.GetById(id);

            if (manufacturer == null)
                return NotFound("Manufacturer with this id not exist");

            return Ok(_repository.Equipments.GetByCondition(e => e.ManufacturerId == id));
        }

        [HttpGet("withOutManufacturer")]
        public IActionResult GetEquipmentsWithoutManufacturer()
        {
            return Ok(_repository.Equipments.GetByCondition(e => e.ManufacturerId == null));
        }

        [HttpPost("add")]
        public IActionResult CreateEquipment([FromBody] CreateEquipmentData createEquipmentData)
        {
            Equipment newEquipment = new Equipment() { Name = createEquipmentData.Name };

            if (createEquipmentData.ManufacturerId != null)
            {
                Manufacturer? manufacturer = _repository.Manufacturers.GetById((int)createEquipmentData.ManufacturerId);

                newEquipment.Manufacturer = manufacturer;
            }

            newEquipment = _repository.Equipments.Create(newEquipment);

            _repository.Save();

            return Ok(newEquipment.Id);
        }

        [HttpDelete("remove/{id}")]
        public IActionResult DeleteEquipment(int id)
        {
            Equipment? equipmentToDelete = _repository.Equipments.GetById(id);

            if (equipmentToDelete == null)
                return NotFound("Equipment with this id was not found");

            _repository.Equipments.Delete(equipmentToDelete);

            _repository.Save();

            return Ok();
        }
    }
}
