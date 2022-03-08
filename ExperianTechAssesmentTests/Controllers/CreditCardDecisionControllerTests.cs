using ExperianTechAssesment.Business.Interfaces;
using ExperianTechAssesment.Business.Models;
using ExperianTechAssesment.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperianTechAssesmentTests.Controllers
{
    [TestClass]
    public class CreditCardDecisionControllerTests
    {
        private IEnumerable<CreditCardOffer> GetRandomOffers()
        {
            var offerOne = new CreditCardOffer(new CreditCard("Barclaycard"), 10.00m, "A test card");
            var offerTwo = new CreditCardOffer(new CreditCard("Barclaycard"), 10.00m, "A test card");
            return new List<CreditCardOffer>() { offerOne, offerTwo };
        }
        [TestMethod]
        public void GetCreditCardOffers_ValidResponse()
        {
            // Arrange
            var applicant = new ApplicantRequest { FirstName = "Marin", LastName = "Dimitrov", AnnualIncome = 5000.00m, DateOfBirth = new DateTime() };
            var mockOfferGenerator = new Mock<ICreditCardOfferGenerator>();
            mockOfferGenerator.Setup(gen => gen.GetCreditCardOffers(applicant)).Returns(GetRandomOffers());
            var controller = new CreditCardDecisionController(mockOfferGenerator.Object);

            // Act
            var result = controller.GetCreditCardOffers(applicant);

            // Assert
            Assert.AreEqual(2, result.Value.Offers.Count());
        }
        [TestMethod]
        public void GetCreditCardOffers_InvalidResponse()
        {
            // Arrange
            var applicant = new ApplicantRequest { FirstName = "Marin", AnnualIncome = 5000.00m, DateOfBirth = new DateTime() };
            var mockOfferGenerator = new Mock<ICreditCardOfferGenerator>();
            mockOfferGenerator.Setup(gen => gen.GetCreditCardOffers(applicant)).Returns(GetRandomOffers());
            var controller = new CreditCardDecisionController(mockOfferGenerator.Object);
            controller.ModelState.AddModelError("LastName", "Required");
            // Act
            var result = controller.GetCreditCardOffers(applicant);

            // Assert
            Assert.AreEqual(result.Result.GetType(), typeof(BadRequestResult));
        }
    }
}
