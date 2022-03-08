using ExperianTechAssesment.Business.Interfaces;
using ExperianTechAssesment.Business.Models;
using System.Buffers;
using System.Text;

namespace ExperianTechAssesment.Business.Services
{
    public class CreditCardOfferGenerator : ICreditCardOfferGenerator
    {
        public IEnumerable<CreditCardOffer> GetCreditCardOffers(ApplicantRequest applicant)
        {
            var birthDate = applicant.DateOfBirth.GetValueOrDefault();
            List<CreditCardOffer> offers = new List<CreditCardOffer>();
            if(CalculateAge(birthDate, DateTime.Now) >= 18 && applicant.AnnualIncome > 30000.00m)
            {
                CreditCard card = new CreditCard("Barclaycard");
                offers.Add(new CreditCardOffer(card, 15.00m, "Best offer!"));
            }
            else if (CalculateAge(birthDate, DateTime.Now) >= 18)
            {
                CreditCard card = new CreditCard("Vanquis");
                offers.Add(new CreditCardOffer(card, 10.00m, "Second best offer!"));
            }
            return offers;
        }

        private int CalculateAge(DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;

            return age;
        }
    }
}
