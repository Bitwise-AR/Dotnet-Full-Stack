public class Appointment
    {
        public void Schedule(Patient p, Doctor d)
        {
            Console.WriteLine($"Appointment scheduled for Patient: {p.Name} with Doctor: {d.Name}");
        }

        public void Schedule(Patient p, Doctor d, DateTime date, string mode = "Offline")
        {
            Console.WriteLine($"Appointment scheduled for Patient: {p.Name} with Doctor: {d.Name} on {date:yyyy-MM-dd} in {mode} mode");
        }
    }