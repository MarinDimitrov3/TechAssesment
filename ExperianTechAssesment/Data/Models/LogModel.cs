using System.Dynamic;

namespace ExperianTechAssesment.Data.Models
{
    public class LogModel
    {
        public ExpandoObject Request { get; set; }
        public ExpandoObject Response { get; set; }
        public DateTime DateOfLog { get; set; } 
    }
}
