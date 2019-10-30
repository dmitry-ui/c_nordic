using Microsoft.AspNetCore.Mvc;
using L22_C01_empty_asp_net_core_app.DataStore;
using System.Linq;
using L22_C01_empty_asp_net_core_app.Models;

namespace L22_C01_empty_asp_net_core_app.Controllers
{
	public class CitiesController : Controller
	{
		[HttpGet("/api/cities")]
		public IActionResult GetCities()
		{
			var citiesDataStore = CitiesDataStore.GetInstance();
			var cityGetModelList = 
				citiesDataStore.Cities
					.Values
					.Select(x => new CityGetModel(x))
					.ToList();

			return Ok(cityGetModelList);
		}

		[HttpGet("/api/cities/{id}")]
		public IActionResult GetCity(int id)
		{
			var citiesDataStore = CitiesDataStore.GetInstance();

			if (citiesDataStore.Cities.ContainsKey(id))
			{
				City city = citiesDataStore.Cities[id];
				return Ok(new CityGetModel(city));
			}
			
			return NotFound();
		}

		[HttpPost("/api/cities/")]
		public IActionResult AddCity([FromBody] CityCreateModel cityCreateModel)
		{

			if (cityCreateModel == null)
				return BadRequest();

			//собственная проверка
			//if (cityCreateModel.Name == cityCreateModel.Description)
			//	ModelState.AddModelError("Custom", "Description wrong");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var citiesDataStore = CitiesDataStore.GetInstance();

			int id = citiesDataStore.Cities.Keys.Max() + 1;
			City city = cityCreateModel.ConvertToCity(id);
			citiesDataStore.Cities.Add(city.Id, city);

			return Created($"/api/cities/{id}", new CityGetModel(city));
		}

		[HttpDelete("/api/cities/{id}")]
		public IActionResult DeleteCity(int id)
		{
			var citiesDataStore = CitiesDataStore.GetInstance();

			if (citiesDataStore.Cities.ContainsKey(id))
			{
				citiesDataStore.Cities.Remove(id);
				return NoContent();
			}

			return NotFound();
		}


		[HttpPut("/api/cities/{id}")]
		public IActionResult ReplaceCity(int id, [FromBody] CityCreateModel cityCreateModel)
		{
			var citiesDataStore = CitiesDataStore.GetInstance();

			if (citiesDataStore.Cities.ContainsKey(id))
			{
				citiesDataStore.Cities[id].Name = cityCreateModel.Name;
				citiesDataStore.Cities[id].Description = cityCreateModel.Description;
				citiesDataStore.Cities[id].NumberOfPointsOfInterest = cityCreateModel.NumberOfPointsOfInterest;
				return Ok(new CityGetModel(citiesDataStore.Cities[id]));
			}

			return NotFound();
		}
	}
}
