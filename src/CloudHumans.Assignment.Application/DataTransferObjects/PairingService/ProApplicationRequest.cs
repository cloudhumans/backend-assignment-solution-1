using System.Text.Json.Serialization;

namespace CloudHumans.Assignment.Application.DataTransferObjects.PairingService
{
    public class ProApplicationRequest
    {
        public int Age { get; set; }

        [JsonPropertyName("education_level")]
        public string EducationLevel { get; set; }

        [JsonPropertyName("past_experiences")]
        public PastExperiencesData PastExperiences { get; set; }

        [JsonPropertyName("internet_test")]
        public InternetTestData InternetTest { get; set; }

        [JsonPropertyName("writing_score")]
        public float WritingScore { get; set; }

        [JsonPropertyName("referral_code")]
        public string ReferralCode { get; set; }

        public class PastExperiencesData
        {
            public bool Sales { get; set; }
            public bool Support { get; set; }
        }

        public class InternetTestData
        {
            [JsonPropertyName("download_speed")]
            public float DownloadSpeed { get; set; }

            [JsonPropertyName("upload_speed")]
            public float UploadSpeed { get; set; }
        }

        public float DownloadSpeed => InternetTest?.DownloadSpeed ?? 0;
        public float UploadSpeed => InternetTest?.UploadSpeed ?? 0;
        public bool SalesExperience => PastExperiences?.Sales ?? false;
        public bool SupportExperience => PastExperiences?.Support ?? false;
    }
}