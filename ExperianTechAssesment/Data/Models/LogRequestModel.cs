using ExperianTechAssesment.Business.Models;

namespace ExperianTechAssesment.Data.Models
{
    public class LogRequestModel
    {
        public string Scheme { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public ApplicantRequest RequestBody { get; set; }
    }
}
