using System.Linq;
using LanguageExt;

namespace CloudHumans.Assignment.Domain.ValueObjects.ProApplication
{
    public class InternetTestResult : Record<InternetTestResult>, IEligibilityScorePoints
    {
        private InternetTestResult(float downloadSpeed, float uploadSpeed, int points)
        {
            this.DownloadSpeed = downloadSpeed;
            this.UploadSpeed = uploadSpeed;
            this.Points = points;
        }

        public float DownloadSpeed { get; }

        public float UploadSpeed { get; }

        public int Points { get; }

        public static InternetTestResult FromFloat(float downloadSpeed, float uploadSpeed)
        {
            if (downloadSpeed >= 0 && uploadSpeed >= 0)
            {
                var score = new float[] { downloadSpeed, uploadSpeed }.Select(GetPointsGivenSpeed).Sum();
                return new InternetTestResult(downloadSpeed, uploadSpeed, score);
            }

            throw new BusinessException(3, "Both the download and upload speed fields must be greater than 0.");
        }

        private static int GetPointsGivenSpeed(float speed)
        {
            if (speed > 50) return 1;
            if (speed < 5) return -1;
            return 0;
        }
    }
}