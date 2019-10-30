using L22_C01_empty_asp_net_core_app.DataStore;
using L22_C01_empty_asp_net_core_app.DataValidation;
using System.ComponentModel.DataAnnotations;


namespace L22_C01_empty_asp_net_core_app.Models
{
	public class CityCreateModel
	{
		[Required(ErrorMessage ="Поле Name необходимо заполнить")]
		[MaxLength(100)]
		public string Name { get; set; }

		[MaxLength(255)]
		[OtherValue("Name")]
		public string Description { get; set; }

		[Range(0,100)]
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
