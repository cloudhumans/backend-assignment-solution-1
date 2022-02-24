using LanguageExt;
using static LanguageExt.Prelude;
using System.Collections.Generic;
using CloudHumans.Assignment.Application.DataTransferObjects.PairingService;
using CloudHumans.Assignment.Domain.Aggregates;
using CloudHumans.Assignment.Domain.ValueObjects.ProApplication;
using System.Linq;

namespace CloudHumans.Assignment.Application
{
    public class PairingService
    {
        public PairingResponse PairProToProject(ProApplicationRequest requestData)
        {
            var proApplication = new ProApplication(
                Age.FromInteger(requestData.Age),
                EducationLevel.FromString(requestData.EducationLevel),
                PastExperience.FromBooleans(requestData.SalesExperience, requestData.SupportExperience).ToList(),
                InternetTestResult.FromFloat(requestData.DownloadSpeed, requestData.UploadSpeed),
                WritingScore.FromFloat(requestData.WritingScore),
                GetReferralCodeFromRepository(requestData.ReferralCode));

            var pairing = Pairing.PerformPairing(proApplication, GetProjectsFromRepository());

            return PairingResponse.Create(pairing);
        }

        private Option<ReferralCode> GetReferralCodeFromRepository(string referralCode)
        {
            if (string.IsNullOrEmpty(referralCode)) return None;

            if (referralCode == "token1234")
                return Some(ReferralCode.CreateValid(referralCode));

            return Some(ReferralCode.CreateInvalid(referralCode));
        }

        private List<Project> GetProjectsFromRepository() => new List<Project> {
                new Project("calculate_dark_matter_nasa", 10),
                new Project("determine_schrodinger_cat_is_alive", 5),
                new Project("support_users_from_xyz", 3),
                new Project("collect_information_for_xpto", 2)};
    }
}
