
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;


namespace Tamga_Test_WebApp.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EqualOrGreaterValidationAttribute : ValidationAttribute, IClientModelValidator
    {
        public string OtherProperty { get; private set; }

        public EqualOrGreaterValidationAttribute(String compareValueName)
        {
            if (String.IsNullOrWhiteSpace(compareValueName))
            {
                throw new ArgumentException(nameof(compareValueName));
            }
            OtherProperty = compareValueName;
        }


        public override bool RequiresValidationContext
        {
            get
            {
                return true;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, OtherProperty);
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            if (otherPropertyInfo == null)
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, OtherProperty));
            }

            object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            decimal decValue;
            decimal decOtherPropertyValue;

            // Check to ensure the validating property is numeric
            if (!decimal.TryParse(value.ToString(), out decValue))
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "{0} is not a numeric value.", validationContext.DisplayName));
            }

            // Check to ensure the other property is numeric
            if (!decimal.TryParse(otherPropertyValue.ToString(), out decOtherPropertyValue))
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "{0} is not a numeric value.", OtherProperty));
            }
                 
           
            if (decValue < decOtherPropertyValue)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return null;
        }




        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
           
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-equalorgreater", ErrorMessage);

          //  var year = _year.ToString(CultureInfo.InvariantCulture);
            MergeAttribute(context.Attributes, "data-val-equalorgreater-other", "*."+OtherProperty);
        }

        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }

            attributes.Add(key, value);
            return true;
        }


    }

}
