using System;
using System.ComponentModel.DataAnnotations;
using VidlyF.Web.Models;


namespace VidlyF.Web.ViewModels
{
    public class Min18 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (CustomerFormViewModel)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.DateTime == null)
                return new ValidationResult("Birthdate is required");

            var age = DateTime.Today.Year - customer.DateTime.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer must be at least 18");

        }
    }
}