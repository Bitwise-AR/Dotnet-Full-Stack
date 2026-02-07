using AutonomousRobot.AI;
class Program
{
    public static void Main()
    {
        List<SensorReading> sensorHistory = new List<SensorReading>
        {
            new SensorReading { SensorId = 1, Type = "Distance", Value = 0.8, Confidence = 0.9, Timestamp = new DateTime(2026,1,12,10,0,1) },
            new SensorReading { SensorId = 2, Type = "Battery", Value = 18, Confidence = 0.8, Timestamp = new DateTime(2026,1,12,10,0,3) },
            new SensorReading { SensorId = 3, Type = "Temperature", Value = 92, Confidence = 0.7, Timestamp = new DateTime(2026,1,12,10,0,4) },
            new SensorReading { SensorId = 4, Type = "Vibration", Value = 8.2, Confidence = 0.6, Timestamp = new DateTime(2026,1,12,10,0,6) },
            new SensorReading { SensorId = 5, Type = "Battery", Value = 75, Confidence = 0.9, Timestamp = new DateTime(2026,1,12,10,0,8) },
            new SensorReading { SensorId = 6, Type = "Distance", Value = 2.5, Confidence = 0.5, Timestamp = new DateTime(2026,1,12,10,0,9) }
        };
        DateTime cutoff = new DateTime(2026, 1, 12, 10, 0, 0);

        DecisionEngine obj = new DecisionEngine();
        List<SensorReading> recentReadings = obj.GetRecentReadings(sensorHistory, cutoff);
        Console.WriteLine("Recent Readings: ");
        foreach (var r in recentReadings)
        {
            Console.WriteLine(" Sensor: " + r.Type + ", Value:" + r.Value);
        }

        Console.WriteLine("Battery Critical: " + obj.IsBatteryCritical(recentReadings));
        Console.WriteLine("Nearest Obstacle: " + obj.GetNearestObstacleDistance(sensorHistory));
        Console.WriteLine("Temperature safe: " + obj.IsTemperatureSafe(sensorHistory));
        Console.WriteLine("Average vibration: " + obj.GetAverageVibration(sensorHistory));

        var sensorHealth = obj.CalculateSensorHealth(sensorHistory);
        Console.WriteLine("Sensor Health: ");
        foreach (var kv in sensorHealth)
        {
            Console.WriteLine(" " + kv.Key + " -> " + kv.Value);
        }

        var faultySensors = obj.DetectFaultySensors(sensorHistory);
        Console.WriteLine("Faulty Sensors: ");
        foreach (var sen in faultySensors)
        {
            Console.WriteLine(" " + sen + " ");
        }
        Console.WriteLine("Battery Draining Fast: " + obj.IsBatteryDrainingFast(sensorHistory));
        Console.WriteLine("Weighted Distance: " + obj.GetWeightedDistance(sensorHistory));
        Console.WriteLine("Robot Action: " + obj.DecideRobotAction(recentReadings, sensorHistory));
    }
}