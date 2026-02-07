using System;
using System.Linq;

namespace AutonomousRobot.AI
{
    class SensorReading
    {
        public int SensorId;
        public string Type;
        public double Value;
        public DateTime Timestamp;
        public double Confidence;
    }

    enum RobotAction
    {
        Stop,
        SlowDown,
        Reroute,
        Continue
    }

    class DecisionEngine
    {
        public List<SensorReading> GetRecentReadings(List<SensorReading> sensorHistory, DateTime fromTime)
        {
            return sensorHistory.Where(reading => reading.Timestamp >= fromTime).ToList();
        }

        public bool IsBatteryCritical(List<SensorReading> readings)
        {
            return readings.Where(s => s.Type == "Battery").Any(s => s.Value < 20);
        }

        public double GetNearestObstacleDistance(List<SensorReading> readings)
        {
            return readings.Where(s => s.Type == "Distance").Min(s => s.Value);
        }

        public bool IsTemperatureSafe(List<SensorReading> readings)
        {
            return readings.Where(s => s.Type == "Temperature").All(s => s.Value < 90);
        }

        public double GetAverageVibration(List<SensorReading> readings)
        {
            return readings.Where(s => s.Type == "Vibration").DefaultIfEmpty().Average(s => s.Value);
        }

        public Dictionary<string, double> CalculateSensorHealth(List<SensorReading> readings)
        {
            return readings.GroupBy(s => s.Type).ToDictionary(g => g.Key, g => g.Average(s => s.Confidence));
        }

        public List<string> DetectFaultySensors(List<SensorReading> readings)
        {
            return readings.Where(s => s.Confidence < 0.4).GroupBy(s => s.Type).Where(g => g.Count() > 2).Select(g => g.Key).ToList();
        }

        public bool IsBatteryDrainingFast(List<SensorReading> readings)
        {
            var temp = readings.Where(s => s.Type == "Battery").OrderBy(s => s.Timestamp);
            if (temp.Count() < 2) return false;

            return temp.Zip(temp.Skip(1), (prev, curr) => curr.Value < prev.Value).All(x => x);
        }

        public double GetWeightedDistance(List<SensorReading> readings)
        {
            double weightedSum = readings.Where(s => s.Type == "Distance").Select(s => s.Value * s.Confidence).Sum();
            double totalConfidence = readings.Where(s => s.Type == "Distance").Sum(s => s.Confidence);

            if (totalConfidence == 0) return double.MaxValue;
            return weightedSum / totalConfidence;
        }

        public RobotAction DecideRobotAction(List<SensorReading> recentReadings, List<SensorReading> sensorHistory)
        {
            if (IsBatteryCritical(recentReadings))
            {
                return RobotAction.Stop;
            }
            if (IsBatteryDrainingFast(sensorHistory))
            {
                return RobotAction.Stop;
            }
            if (GetNearestObstacleDistance(recentReadings) < 1.0)
            {
                return RobotAction.Reroute;
            }
            if (!IsTemperatureSafe(recentReadings))
            {
                return RobotAction.SlowDown;
            }

            return RobotAction.Continue;
        }

    }
}