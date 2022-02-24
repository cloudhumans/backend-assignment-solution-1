using LanguageExt;

namespace CloudHumans.Assignment.Domain.ValueObjects.ProApplication
{
    public class ReferralCode : Record<ReferralCode>, IEligibilityScorePoints
    {
        private ReferralCode(string code, int points)
        {
            this.Code = code;
            this.Points = points;
        }

        public string Code { get; }

        public int Points { get; }

        public static ReferralCode CreateValid(string code) => new ReferralCode(code, 1);

        public static ReferralCode CreateInvalid(string code) => new ReferralCode(code, 0);
    }
}