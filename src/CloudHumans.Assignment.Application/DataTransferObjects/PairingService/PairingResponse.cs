using System.Linq;
using System.Text.Json.Serialization;
using CloudHumans.Assignment.Domain.Aggregates;
using System.Collections.Generic;

namespace CloudHumans.Assignment.Application.DataTransferObjects.PairingService
{
    public class PairingResponse
    {
        public int Score { get; set; }

        [JsonPropertyName("selected_project")]
        public string SelectedProject { get; set; }

        [JsonPropertyName("eligible_projects")]
        public List<string> EligibleProjects { get; set; }

        [JsonPropertyName("ineligible_projects")]
        public List<string> IneligibleProjects { get; set; }

        public static PairingResponse Create(Pairing pairing) => new PairingResponse
        {
            Score = pairing.ProApplication.GetEligibilityScore(),
            SelectedProject = pairing.SelectedProject.Map(project => project.Description).IfNone(string.Empty),
            EligibleProjects = pairing.EligibleProjects.Map(project => project.Description).ToList(),
            IneligibleProjects = pairing.IneligibleProjects.Map(project => project.Description).ToList(),
        };
    }
}