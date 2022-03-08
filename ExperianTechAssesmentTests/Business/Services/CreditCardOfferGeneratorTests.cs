using ExperianTechAssesment.Business.Models;
using ExperianTechAssesment.Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ExperianTechAssesmentTests
{
    [TestClass]
    public class CreditCardOfferGeneratorTests
    {
        private readonly CreditCardOfferGenerator _creditCardOfferGenerator;

        public CreditCardOfferGeneratorTests()
        {
            _creditCardOfferGenerator = new CreditCardOfferGenerator();
        }

        [TestMethod]
        public void GetCreditCardOffers_NoCard()
        {
            ApplicantRequest applicant = new ApplicantRequest() { FirstName = "Marin", LastName = "Dimitrov", AnnualIncome = 45000.00m, DateOfBirth = DateTime.Parse("2010-05-16")}; 

            var offers = _creditCardOfferGenerator.GetCreditCardOffers(applicant).ToArray();
            Assert.AreEqual(0, offers.Count());
        }

        [TestMethod]
        public void GetCreditCardOffers_VanquisCard()
        {
            ApplicantRequest applicant = new ApplicantRequest() { FirstName = "Marin", LastName = "Dimitrov", AnnualIncome = 45000.00m, DateOfBirth = DateTime.Parse("2000-05-16") };

            var offers = _creditCardOfferGenerator.GetCreditCardOffers(applicant).ToArray();
            Assert.AreEqual(1, offers.Count());
            Assert.AreEqual("Barclaycard", offers[0].Card.CardName);
        }

        [TestMethod]
        public void GetCreditCardOffers_BarclaycardCard()
        {
            ApplicantRequest applicant = new ApplicantRequest() { FirstName = "Marin", LastName = "Dimitrov", AnnualIncome = 15000.00m, DateOfBirth = DateTime.Parse("2000-05-16") };

            var offers = _creditCardOfferGenerator.GetCreditCardOffers(applicant).ToArray();
            Assert.AreEqual(1, offers.Count());
            Assert.AreEqual("Vanquis", offers[0].Card.CardName);
        }
    }
}