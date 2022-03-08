using ExperianTechAssesment.Business.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ExperianTechAssesment.Business.Models
{
    public record class ApplicantRequest
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "DateOfBirth is required")]
        [StartDate(ErrorMessage = "Date of birth should be earlier than today")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "AnnualIncome is required")]
        [Range(0, 99999999999.99)]
        public decimal? AnnualIncome { get; set; }
    }
}
