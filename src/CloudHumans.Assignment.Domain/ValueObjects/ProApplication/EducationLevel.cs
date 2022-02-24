using LanguageExt;

namespace CloudHumans.Assignment.Domain.ValueObjects.ProApplication
{
    public class EducationLevel : Record<EducationLevel>, IEligibilityScorePoints
    {
        private EducationLevel(string description, int points)
        {
            this.Description = description;
            this.Points = points;
        }

        public string Description { get; }

        public int Points { get; }

        public static EducationLevel FromString(string educationLevel)
        {
            switch (educationLevel)
            {
                case "no_education": return new EducationLevel(educationLevel, 0);
                case "high_school": return new EducationLevel(educationLevel, 1);
                case "bachelors_degree_or_high": return new EducationLevel(educationLevel, 3);
                default: throw new BusinessException(2, "The education level specified is not valid.");
            }
        }
    }
}