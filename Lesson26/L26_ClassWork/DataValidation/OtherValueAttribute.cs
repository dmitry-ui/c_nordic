using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace L26_ClassWork.DataValidation
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class OtherValueAttribute : ValidationAttribute
	{
		public OtherValueAttribute(string otherProperty)
		{
			if (otherProperty == null)
				throw new ArgumentNullException("otherProperty");

			OtherProperty = otherProperty;
		}

		public override bool RequiresValidationContext
		{
			get
			{
				return true;
			}
		}

		public string OtherProperty { get; private set; }

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
			if (otherPropertyInfo == null)
			{
				return new ValidationResult($"Cannot find the property having name \"{OtherProperty}\"");
			}

			object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
			if (Equals(value, otherPropertyValue))
			{
				return new ValidationResult(
					$"{validationContext.MemberName} shouldn't be the same as {OtherProperty}");
			}

			return null;
		}
	}
}
