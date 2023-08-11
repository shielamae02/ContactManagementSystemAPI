using Backend.Models.Contacts;
using System.ComponentModel.DataAnnotations;

namespace Backend.Utils
{
    public class AtLeastOneContactNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            var contact = (AddContactDto)validationContext.ObjectInstance;
            if(contact is null || (contact.ContactNumbers is null || contact.ContactNumbers.Count == 0))
            {
                return new ValidationResult("At least one contact number is required.");
            }
            return ValidationResult.Success;
        }
    }
}
