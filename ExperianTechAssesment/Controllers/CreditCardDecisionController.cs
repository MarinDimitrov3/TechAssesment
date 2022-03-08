using ExperianTechAssesment.Business.Interfaces;
using ExperianTechAssesment.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExperianTechAssesment.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CreditCardDecisionController : ControllerBase
    {
        private readonly ICreditCardOfferGenerator _offerGenerator;

        public CreditCardDecisionController(ICreditCardOfferGenerator offerGenerator)
        {
            _offerGenerator = offerGenerator;
        }

        [HttpPost("GetCreditCardOffers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CreditCardOfferResponse> GetCreditCardOffers([FromBody] ApplicantRequest applicantRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            IEnumerable<CreditCardOffer> offers = _offerGenerator.GetCreditCardOffers(applicantRequest);
            return new CreditCardOfferResponse(offers);
        }
    }
}