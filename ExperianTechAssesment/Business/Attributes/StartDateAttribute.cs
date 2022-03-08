using System.ComponentModel.DataAnnotations;

namespace ExperianTechAssesment.Business.Attributes
{
    public class StartDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime _dateStart = Convert.ToDateTime(value);
            if (_dateStart < DateTime.Today)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }
}
