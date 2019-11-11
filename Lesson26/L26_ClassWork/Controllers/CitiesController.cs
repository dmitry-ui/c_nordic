using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DataStore.Core;
using L26_ClassWork.Models;

namespace L26_ClassWork.Controllers
{
	[Route("/api/cities")]
	public class CitiesController : Controller
	{
		private ICitiesDataStore _citiesDataStore;
		private ILogger<CitiesController> _logger;

		public CitiesController(
			ICitiesDataStore citiesDataStore,
			ILogger<CitiesController> logger)
		{
			_citiesDataStore = citiesDataStore;
			_logger = logger;
		}

		[HttpGet]
		public IActionResult GetCities()
		{
			_logger.LogInformation("Method GetCities() called.");

			try
			{
				var cityGetModelList =
					_citiesDataStore.Cities
						.Values
						.Select(x => new CityGetModel(x))
						.ToList();

				return Ok(cityGetModelList);
			}
			catch (Exception exception)
			{
				_logger.LogError(
					exception,
					"Error in GetCities() method.");

				throw;
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetCity(int id)
		{
			if (id <= 0)
				ModelState.AddModelError("id", "ID should be an integer value greater than 0.");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (_citiesDataStore.Cities.ContainsKey(id))
			{
				City city = _citiesDataStore.Cities[id];
				return Ok(new CityGetModel(city));
			}

			return NotFound();
		}

		[HttpPost]
		public IActionResult AddCity([FromBody] CityCreateModel cityCreateModel)
		{
			if (cityCreateModel == null)
				return BadRequest();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			int id = _citiesDataStore.Cities.Keys.Count == 0
				? 1
				: _citiesDataStore.Cities.Keys.Max() + 1;

			City city = cityCreateModel.ConvertToCity(id);
			_citiesDataStore.Cities.Add(city.Id, city);

			return Created($"/api/cities/{id}", new CityGetModel(city));
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCity(int id)
		{
			if (id <= 0)
				ModelState.AddModelError("id", "ID should be an integer value greater than 0.");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (_citiesDataStore.Cities.ContainsKey(id))
			{
				_citiesDataStore.Cities.Remove(id);
				return NoContent();
			}

			return NotFound();
		}


		[HttpPut("{id}")]
		public IActionResult ReplaceCity(int id, [FromBody] CityCreateModel cityCreateModel)
		{
			if (id <= 0)
				ModelState.AddModelError("id", "ID should be an integer value greater than 0.");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (_citiesDataStore.Cities.ContainsKey(id))
			{
				_citiesDataStore.Cities[id].Name = cityCreateModel.Name;
				_citiesDataStore.Cities[id].Description = cityCreateModel.Description;
				_citiesDataStore.Cities[id].NumberOfPointsOfInterest = cityCreateModel.NumberOfPointsOfInterest;
				return Ok(new CityGetModel(_citiesDataStore.Cities[id]));
			}

			return NotFound();
		}
	}
}
