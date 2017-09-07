using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple=false)]
    sealed public class DateInPast : ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                string strValue = value.ToString();
                var visitDate = DateTime.Parse(strValue);
                if (visitDate >= DateTime.Now)
                {
                    return new ValidationResult("Wow, you ate there in the future?");
                }
                return ValidationResult.Success;
            }
            catch (Exception)
            {
                return new ValidationResult("Something is wrong with the date");
            }
        }
    }

}
