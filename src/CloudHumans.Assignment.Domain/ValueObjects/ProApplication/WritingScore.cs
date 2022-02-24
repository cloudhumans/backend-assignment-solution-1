using LanguageExt;

namespace CloudHumans.Assignment.Domain.ValueObjects.ProApplication
{
    public class WritingScore : Record<WritingScore>, IEligibilityScorePoints
    {
        private WritingScore(float score, int points)
        {
            this.Score = score;
            this.Points = points;
        }

        public float Score { get; }

        public int Points { get; }

        public static WritingScore FromFloat(float score)
        {
            if (score >= 0 && score <= 1) return new WritingScore(score, GetPointsGivenScore(score));

            throw new BusinessException(4, "The score must be a float between 0 and 1.");
        }

        private static int GetPointsGivenScore(float score)
        {
            if (score < 0.3) return -1;
            if (score >= 0.3 && score <= 0.7) return 1;
            return 2;
        }
    }
}