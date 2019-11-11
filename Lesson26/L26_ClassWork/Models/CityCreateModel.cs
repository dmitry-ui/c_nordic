using DataStore.Core;
using L26_ClassWork.DataValidation;
using System.ComponentModel.DataAnnotations;

namespace L26_ClassWork.Models
{
	public class CityCreateModel
	{
		[Required(ErrorMessage = "Поле Name является обязательным")]
		[MaxLength(100)]
		public string Name { get; set; }

		[MaxLength(255)]
		[OtherValue("Name")]
		public string Description { get; set; }

		[Range(0, 100)]
		public int NumberOfPointsOfInterest { get; set; }

		public City ConvertToCity(int id)
		{
			return new City
			{
				Id = id,
				Name = Name,
				Description = Description,
				NumberOfPointsOfInterest = NumberOfPointsOfInterest
			};
		}
	}
}
