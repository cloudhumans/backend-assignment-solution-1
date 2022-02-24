namespace CloudHumans.Assignment.Domain.Aggregates
{
    public class Project
    {
        public Project(string description, int requiredScore)
        {
            Description = description;
            RequiredScore = requiredScore;
        }

        public string Description { get; }

        public int RequiredScore { get; }
    }
}