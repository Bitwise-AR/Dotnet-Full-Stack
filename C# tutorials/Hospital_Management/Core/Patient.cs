public class Patient
    {
        public readonly int PatientId;
        public required string Name { get; set; }
        public int Age { get; set; }
        private string medicalHistory = string.Empty;

        public Patient(int patientId)
        {
            PatientId = patientId;
        }

        public void SetMedicalHistory(string history)
        {
            medicalHistory = history;
        }

        public string GetMedicalHistory()
        {
            return medicalHistory;
        }
    }