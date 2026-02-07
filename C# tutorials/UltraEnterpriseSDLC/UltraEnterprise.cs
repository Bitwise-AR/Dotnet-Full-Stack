namespace UltraEnterpriseSDLC
{
    public enum RiskLevel
    {
        Low,
        Medium,
        High,
        Critical
    }

    public enum SDLCStage
    {
        Backlog = 0,
        Requirement = 1,
        Design = 2,
        Development = 3,
        CodeReview = 4,
        Testing = 5,
        UAT = 6,
        Deployment = 7,
        Maintenance = 8
    }

    sealed class Requirement
    {
        public int Id { get; }
        public string Title { get; }
        public RiskLevel Risk { get; }

        public Requirement(int id, string title, RiskLevel risk)
        {
            Id = id;
            Title = title;
            Risk = risk;
        }
    }

    public sealed class WorkItem
    {
        public int Id { get; }
        public string Name { get; }
        public SDLCStage Stage { get; set; }
        public HashSet<int> DependencyIds { get; }

        public WorkItem(int id, string name, SDLCStage stage)
        {
            Id = id;
            Name = name;
            Stage = stage;
            DependencyIds = new HashSet<int>();
        }
    }

    sealed class BuildSnapshot
    {
        public string Version { get; }
        public DateTime Timestamp { get; }
        public BuildSnapshot(string version)
        {
            Version = version;
            Timestamp = DateTime.Now;
        }
    }

    sealed class AuditLog
    {
        public DateTime Time { get; }
        public string Action { get; }
        public AuditLog(string action)
        {
            Action = action;
            Timestamp = DateTime.Now;
        }
    }

    sealed class QualityMetric
    {
        public string Name { get; }
        public double Score { get; }
        public QualityMetric(string name, double score)
        {
            Name = name;
            Score = score;
        }
    }
}