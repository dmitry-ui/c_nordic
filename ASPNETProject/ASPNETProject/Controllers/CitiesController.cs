using ASPNETProject.DataStore;
using ASPNETProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETProject.Controllers
{
	//создали класс в папке и унаследовали его от контроллера
	public class CitiesController : Controller
	{

		//по какому урлу будет отвечать наш сервис
		//api/cities/
		[HttpGet("/api/cities")]
		//экшн кот вызывается внешним запросом, в коде это метод
		public IActionResult GetCities()
		{
			var citiesDataStore = CitiesDataStore.GetInstance();
			var cities = citiesDataStore.Cities;

			//var result = new JsonResult(cities);
			//result.StatusCode = 200;
			//return result;
			return Ok(cities);
		}

		[HttpGet("/api/cities/{id}")]
		public IActionResult GetCity(int id)
		{
			var citiesDataStore = CitiesDataStore.GetInstance();
			//foreach(City city in citiesDataStore.Cities)
			//{
			//	if(city.Id == id)
			//	{
			//		return new JsonResult(city);
			//	}
			//}
			//return new JsonResult(null);
			//или так
			//return new JsonResult(citiesDataStore.Cities.FirstOrDefault(с => с.Id == id));

			var city = citiesDataStore.Cities.FirstOrDefault(c => c.Id == id);
			if(city ==null)
				return NotFound();
			return Ok(city);

		}

		[HttpPost("/api/cities/")]
		public IActionResult AddCity([FromBody] City city)
		{
			var citiesDataStore = CitiesDataStore.GetInstance();
			citiesDataStore.Cities.Add(city);

			return Created("/api/cities/" + city.Id, city); 
		}

	}
}
