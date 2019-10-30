using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace L22_C01_empty_asp_net_core_app.DataValidation
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class OtherValueAttribute: ValidationAttribute
	{
		public OtherValueAttribute(string otherProperty)
		//   : base(DataAnnotationsResources.CompareAttribute_MustMatch)
		{
			if (otherProperty == null)
			{
				throw new ArgumentNullException("otherProperty");
			}
			OtherProperty = otherProperty;
		}

		public string OtherProperty { get; private set; }

		//public override bool RequiresValidationContext
		//{
		//	get
		//	{
		//		return true;
		//	}
		//}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
			if (otherPropertyInfo == null)
			{
				return new ValidationResult($"Cannot find property having name \"{OtherProperty}\"");
			}

			object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
			if (Equals(value, otherPropertyValue))
			{
				return new ValidationResult(
					$"{validationContext.MemberName} should not be the same as {OtherProperty}");
			}
			return null;
		}

	}
}
