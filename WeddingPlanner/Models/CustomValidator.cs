using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WeddingPlanner.Models
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple=false)]
    sealed public class MinAge : ValidationAttribute
    {
        public int MinimumAge { get; set; }

        public MinAge(int ageValue)
        {
            MinimumAge = ageValue;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                string strValue = value.ToString();
                var dateOfBirth = DateTime.Parse(strValue);
                if (dateOfBirth > DateTime.Now.AddYears(-MinimumAge))
                {
                    return new ValidationResult($"Sorry, you must be at least {MinimumAge} years old to have an account");
                }
                return ValidationResult.Success;
            }
            catch(Exception)
            {
                return new ValidationResult("Please make sure date is correct and try again");
            }
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple=false)]

    sealed public class FutureDate : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            try
            {
                string strValue = value.ToString();
                var WeddingDate = DateTime.Parse(strValue);
                if(WeddingDate < DateTime.Now)
                {
                    return new ValidationResult("Unless you have a time machine you need to plan your wedding in the future");
                }
                return ValidationResult.Success;
            }
            catch(Exception)
            {
                return new ValidationResult("Please make sure date is correct and try again");
            }

        }

    }


    // trying to keep entire unique validation inside of model.
    // code is in progress and isn't working...yet...will revisit in future to get this validation out of the controller
    // [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple=false)]
    // sealed public class IsUniqueUserName : ValidationAttribute
    // {
        // public string DataField { get; set; }
        // private BankContext _context = new BankContext();

        // public IsUniqueUserName(BankContext context)
        // {
            // DataField = field;
        // }

        // protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        // {
            // BankContext _context = new BankContext();

            // try
            // {
                // bool validate = _context.Users.Any(x => x.UserName == (string)value);
            //     if(validate == true)
            //     {
            //         return new ValidationResult($"{DataField} already registered");
            //     }
            //     return ValidationResult.Success;
            // }
            // catch(Exception)
            // {
            //     return new ValidationResult("Please choose another Username");
            // }

        // }
    // }

}