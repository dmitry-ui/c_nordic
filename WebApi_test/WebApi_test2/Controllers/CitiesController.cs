using Microsoft.AspNetCore.Mvc;
using Models;
using Storage;


namespace WebApi_test2.Controllers
{
    public class CitiesController : Controller
    {
        StorageOperations storageOperations = new StorageOperations();

        //получить все города
        [HttpGet("/cities")]
        public IActionResult GetCities()
        {
            return Ok(storageOperations.GetAllCities());
        }

        //получить город по id
        [HttpGet("/cities/{id}")]
        public IActionResult GetCity(int id)
        {
            if (storageOperations.isPrezent(id))
                return Ok(storageOperations.GetCityById(id));
            else return NotFound();
        }

        //добавить новый город
        [HttpPost("/cities")]
        public IActionResult AddCity([FromBody] CityCreateModel city)
        {
            return Ok(storageOperations.AddCity(city));
        }

        //отредактировать город
        [HttpPut("/cities/{id}")]
        public IActionResult UpdateCity(int id, [FromBody] CityGetModel city)
        {
            if (storageOperations.isPrezent(id))
                return Ok(storageOperations.UpdateCity(id, city));
            else return NotFound();
        }

        // удалить город
        [HttpDelete("/cities/{id}")]
        public IActionResult DeleteCity(int id)
        {
            if (storageOperations.isPrezent(id))
                return Ok(storageOperations.DeleteCity(id));
            else return NotFound();
        }
    }
}
