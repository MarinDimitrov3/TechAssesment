using ExperianTechAssesment.Data.Models;
using System.Dynamic;

namespace ExperianTechAssesment.Data.Interfaces
{
    public interface ILogRequestResponse
    {
        Task<bool> LogRequestResponseInDb(ExpandoObject request, ExpandoObject response);
    }
}
