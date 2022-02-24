using LanguageExt;
using System.Linq;
using System.Collections.Generic;
using CloudHumans.Assignment.Domain.ValueObjects.ProApplication;

namespace CloudHumans.Assignment.Domain.Aggregates
{
    public class ProApplication
    {
        public ProApplication(
            Age age,
            EducationLevel educationLevel,
            List<PastExperience> pastExperiences,
            InternetTestResult internetTestResult,
            WritingScore writingScore,
            Option<ReferralCode> referralCode)
        {
            Age = age;
            EducationLevel = educationLevel;
            PastExperiences = pastExperiences;
            InternetTestResult = internetTestResult;
            WritingScore = writingScore;
            ReferralCode = referralCode;
        }

        public Age Age { get; }
        public EducationLevel EducationLevel { get; }
        public List<PastExperience> PastExperiences { get; }
        public InternetTestResult InternetTestResult { get; }
        public WritingScore WritingScore { get; }
        public Option<ReferralCode> ReferralCode { get; }

        public int GetEligibilityScore()
        {
            var referralCodePoints = ReferralCode.Map(scoreInfo => scoreInfo.Points).IfNone(0);

            var pastExperiencePoints = PastExperiences.Select(scoreInfo => scoreInfo.Points).Sum();

            var requiredFieldsPoints = new List<IEligibilityScorePoints>() {
                EducationLevel,
                InternetTestResult,
                WritingScore,
            }.Select(scoreInfo => scoreInfo.Points).Sum();

            return referralCodePoints + pastExperiencePoints + requiredFieldsPoints;
        }
    }
}