using System.Linq;
using UltraEnterpriseSDLC;

namespace UltraEnterpriseSDLC
{
    public class EnterpriseSDLCEngine
    {
        private List<Requirement> _requirements;
        private Dictionary<int, WorkItem> _workItemRegistry;
        private SortedDictionary<SDLCStage, List<WorkItem>> _stageBoard;
        private Queue<WorkItem> _executionQueue;
        private Stack<BuildSnapshot> _rollbackStack;
        private HashSet<string> _uniqueTestSuites;
        private LinkedList<AuditLog> _auditLedger;
        private SortedList<double, QualityMetric> _releaseScoreboard;
        private int _requirementCounter;
        private int _workItemCounter;

        public EnterpriseSDLCEngine()
        {
            _requirements = new List<Requirement>();
            _workItemRegistry = new Dictionary<int, WorkItem>();
            _stageBoard = new SortedDictionary<SDLCStage, List<WorkItem>>();
            _stageBoard.Add(0, new List<WorkItem>());
            _stageBoard.Add((SDLCStage)1, new List<WorkItem>());
            _stageBoard.Add((SDLCStage)2, new List<WorkItem>());
            _stageBoard.Add((SDLCStage)3, new List<WorkItem>());
            _stageBoard.Add((SDLCStage)4, new List<WorkItem>());
            _stageBoard.Add((SDLCStage)5, new List<WorkItem>());
            _stageBoard.Add((SDLCStage)6, new List<WorkItem>());
            _stageBoard.Add((SDLCStage)7, new List<WorkItem>());
            _stageBoard.Add((SDLCStage)8, new List<WorkItem>());
            _executionQueue = new Queue<WorkItem>();
            _rollbackStack = new Stack<BuildSnapshot>();
            _uniqueTestSuites = new HashSet<string>();
            _auditLedger = new LinkedList<AuditLog>();
            _releaseScoreboard = new SortedList<double, QualityMetric>();
        }

        public void AddRequirement(string title, RiskLevel risk)
        {
            Requirement obj = new Requirement(_requirementCounter++, title, risk);
            _requirements.Add(obj);
            AuditLog auditObj = new AuditLog("Added Requirement");
            _auditLedger.AddLast(auditObj);
        }

        public WorkItem CreateWorkItem(string name, SDLCStage stage)
        {
            WorkItem workObj = new WorkItem(_workItemCounter++, name, stage);
            _workItemRegistry.Add(workObj.Id, workObj);
            _stageBoard[stage].Add(workObj);
            AuditLog auditObj = new AuditLog("Created WorkItem");
            _auditLedger.AddLast(auditObj);
            return workObj;
        }

        public void AddDependency(int workItemId, int dependsOnId)
        {
            if (!(_workItemRegistry.ContainsKey(workItemId) && _workItemRegistry.ContainsKey(dependsOnId)))
            {
                return;
            }
            _workItemRegistry[workItemId].DependencyIds.Add(dependsOnId);
            AuditLog auditObj = new AuditLog($"Added Dependency on {workItemId} for {dependsOnId}");
            _auditLedger.AddLast(auditObj);
        }

        public void PlanStage(SDLCStage stage)
        {
            List<WorkItem> list = _stageBoard[stage];
            foreach (var i in list)
            {
                if (i.DependencyIds.All(r => _workItemRegistry[r].Stage <= stage))
                {
                    _executionQueue.Enqueue(i);
                }
            }
            AuditLog auditObj = new AuditLog($"Stage {stage} planned");
            _auditLedger.AddLast(auditObj);
        }

        public void ExecuteNext()
        {
            if (_executionQueue.Count == 0)
            {
                return;
            }
            WorkItem obj = _executionQueue.Dequeue();
            SDLCStage stage = obj.Stage;
            obj.Stage++;
            _stageBoard[stage].Remove(obj);
            _stageBoard[obj.Stage].Add(obj);
            AuditLog auditObj = new AuditLog($"WorkItem {obj.Id} moved from Stage {stage} to Stage {obj.Stage}");
            _auditLedger.AddLast(auditObj);
        }

        public void RegisterTestSuite(string suitId)
        {
            _uniqueTestSuites.Add(suitId);
            AuditLog auditObj = new AuditLog($"Suite {suitId} registered successfully");
            _auditLedger.AddLast(auditObj);
        }

        public void DeployRelease(string version)
        {
            BuildSnapshot obj = new BuildSnapshot(version);
            _rollbackStack.Push(obj);
            AuditLog auditObj = new AuditLog($"Added Snapshot {version}");
            _auditLedger.AddLast(auditObj);
        }

        public void RollbackRelease()
        {
            if (_rollbackStack.Count == 0)
            {
                return;
            }
            BuildSnapshot obj = _rollbackStack.Pop();
            AuditLog auditObj = new AuditLog($"Rollback snapshot {obj.Version}");
            _auditLedger.AddLast(auditObj);
        }

        public void RecordQualityMetric(string metricName, double score)
        {
            if (_releaseScoreboard.ContainsKey(score))
            {
                return;
            }
            QualityMetric obj = new QualityMetric(metricName, score);
            _releaseScoreboard.Add(score, obj);
            AuditLog auditObj = new AuditLog($"Quality Metric with score {score} added successfully");
            _auditLedger.AddLast(auditObj);
        }

        public void PrintAuditLedger()
        {
            foreach (var i in _auditLedger)
            {
                Console.WriteLine(i.Action + " " + i.Time);
            }
        }

        public void PrintReleaseScoreboard()
        {
            foreach (var i in _releaseScoreboard)
            {
                Console.WriteLine($"Metric Name {i.Value.Name} with score {i.Key:0.00}");
            }
        }
    }
}