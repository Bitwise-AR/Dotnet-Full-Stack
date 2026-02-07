using System;
using UltraEnterpriseSDLC;

class Program
{
    static void main(string[] args)
    {
        EnterpriseSDLCEngine engine = new EnterpriseSDLCEngine();
        engine.AddRequirement("Sign-On", High);
        engine.AddRequirement("Fraud Detection", Critical);
        WorkItem obj1 = engine.CreateWorkItem("Sign-On", Design);
        WorkItem obj2 = engine.CreateWorkItem("Sign-On", Development);
        WorkItem obj3 = engine.CreateWorkItem("Sign-On", Testing);
        engine.AddDependency(obj2.id, obj1.id);
        engine.AddDependency(obj3.id, obj2.id);
        engine.RegisterTestSuite("Regression test suite");
        engine.RegisterTestSuite("Smoke test suite");
        engine.PlanStage(Design);
        engine.ExecuteNext();
        engine.ExecuteNext();
        engine.DeployRelease("v3.4.1");
        engine.RecordQualityMetric("Code Coverage", 91.7);
        engine.RecordQualityMetric("Security Coverage", 97.3);
        engine.RollbackRelease();
        engine.PrintAuditLedger();
        engine.PrintReleaseScoreboard();
    }
}