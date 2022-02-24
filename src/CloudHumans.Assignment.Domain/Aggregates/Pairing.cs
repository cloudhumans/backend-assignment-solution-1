using LanguageExt;
using System.Linq;
using System.Collections.Generic;

namespace CloudHumans.Assignment.Domain.Aggregates
{
    public class Pairing
    {
        private Pairing(ProApplication proApplication, Option<Project> selectedProject, List<Project> eligibleProjects, List<Project> ineligibleProjects)
        {
            ProApplication = proApplication;
            SelectedProject = selectedProject;
            EligibleProjects = eligibleProjects;
            IneligibleProjects = ineligibleProjects;
        }

        public ProApplication ProApplication { get; }
        public Option<Project> SelectedProject { get; }
        public List<Project> EligibleProjects { get; }
        public List<Project> IneligibleProjects { get; }

        public static Pairing PerformPairing(ProApplication proApplication, List<Project> availableProjects)
        {
            var proEligibilityScore = proApplication.GetEligibilityScore();

            var eligibleProjects = availableProjects
                .Filter(project => proEligibilityScore > project.RequiredScore)
                .OrderBy(project => project.RequiredScore);

            var ineligibleProjects = availableProjects.Filter(project => proEligibilityScore <= project.RequiredScore);

            var selectedProject = eligibleProjects.LastOrNone();

            return new Pairing(proApplication, selectedProject, eligibleProjects.ToList(), ineligibleProjects.ToList());
        }
    }
}