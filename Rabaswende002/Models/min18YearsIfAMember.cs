using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Rabaswende002.Models
{
    public class min18YearsIfAMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

          var customer =  (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.payAsYouGo || customer.MembershipTypeId == MembershipType.Unknown )
                return ValidationResult.Success;
            if (customer.Birthdate == null)
                return new ValidationResult("Birthday id required.");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("customer should be a least 18 years old to go on a membeshyp");

           
        }

    }
}