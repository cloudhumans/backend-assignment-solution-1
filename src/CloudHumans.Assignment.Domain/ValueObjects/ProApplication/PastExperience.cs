using System.Collections.Generic;
using LanguageExt;

namespace CloudHumans.Assignment.Domain.ValueObjects.ProApplication
{
    public class PastExperience : Record<PastExperience>, IEligibilityScorePoints
    {
        private PastExperience(string description, int points)
        {
            this.Description = description;
            this.Points = points;
        }

        public string Description { get; }

        public int Points { get; }

        public static IEnumerable<PastExperience> FromBooleans(bool sales, bool support)
        {
            if (sales) yield return new PastExperience("sales", 5);

            if (support) yield return new PastExperience("support", 3);
        }
    }
}