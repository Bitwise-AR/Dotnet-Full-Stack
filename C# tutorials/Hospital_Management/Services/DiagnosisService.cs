public class DiagnosisService
    {
        public void Evaluate(in int age, ref string condition, out string riskLevel, params int[] testScores)
        {
            static bool IsCritical(int sum)
            {
                return sum > 250;
            }

            int totalScore = 0;
            foreach (int score in testScores)
            {
                totalScore += score;
            }

            if (IsCritical(totalScore) || age > 60)
            {
                condition = "Serious";
                riskLevel = "High";
            }
            else
            {
                riskLevel = "Moderate";
            }
        }
    }