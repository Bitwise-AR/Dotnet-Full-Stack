public class Program
{
    public const string HospitalName = "Integrated Hospital Care Management System";

    static Program()
    {
        Console.WriteLine($"System Boot: {HospitalName} Initialized");
    }

    public static void Main(string[] args)
    {
        try
        {
            // Initialize system components
            var inputHelper = new InputHelper();
            var diagnosisService = new DiagnosisService();
            var insuranceService = new InsuranceService();
            var appointment = new Appointment();

            // Read patient details
            Console.Write("Enter Patient ID: ");
            int patientId = inputHelper.ReadAge(Console.ReadLine() ?? "0");

            Console.Write("Enter Patient Name: ");
            string patientName = Console.ReadLine() ?? "Unknown";

            Console.Write("Enter Patient Age: ");
            int patientAge = inputHelper.ReadAge(Console.ReadLine() ?? "0");

            // Create Patient object
            var patient = new Patient(patientId)
            {
                Name = patientName,
                Age = patientAge
            };

            // Assign medical history
            Console.Write("Enter Medical History: ");
            patient.SetMedicalHistory(Console.ReadLine() ?? "");

            // Read doctor details
            Console.Write("Enter Doctor License Number: ");
            string licenseNumber = Console.ReadLine() ?? "UNKNOWN";

            Console.Write("Enter Doctor Name: ");
            string doctorName = Console.ReadLine() ?? "Unknown";

            // Create Doctor object
            var doctor = new Doctor(licenseNumber)
            {
                Name = doctorName
            };

            // Schedule appointment
            appointment.Schedule(patient, doctor, DateTime.Now);

            // Perform diagnosis evaluation
            string condition = "";
            Console.Write("Enter test scores (comma separated): ");
            string[] scoreInputs = (Console.ReadLine() ?? "").Split(',');
            int[] testScores = new int[scoreInputs.Length];

            for (int i = 0; i < scoreInputs.Length; i++)
            {
                testScores[i] = inputHelper.ReadAge(scoreInputs[i].Trim());
            }

            int patientAge2 = patient.Age;
            diagnosisService.Evaluate(in patientAge2, ref condition, out string riskLevel, testScores);
            Console.WriteLine($"Diagnosis: {condition}, Risk Level: {riskLevel}");

            // Generate hospital bill using object initializer
            Console.Write("Enter Consultation Fee: ");
            double consultationFee = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter Test Charges: ");
            double testCharges = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter Room Charges: ");
            double roomCharges = double.Parse(Console.ReadLine() ?? "0");

            var bill = new Billing
            {
                ConsultationFee = consultationFee,
                TestCharges = testCharges,
                RoomCharges = roomCharges
            };

            double totalBill = bill.Total();
            Console.WriteLine($"Total Bill: ₹{totalBill:F2}");

            // Apply insurance coverage
            Console.Write("Enter Insurance Coverage Percentage: ");
            int coveragePercent = inputHelper.ReadAge(Console.ReadLine() ?? "0");

            double finalAmount = insuranceService.ApplyCoverage(totalBill, coveragePercent);
            Console.WriteLine($"Final Payable Amount: ₹{finalAmount:F2}");

            Console.WriteLine($"Total Doctors in Hospital: {Doctor.TotalDoctors}");
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid Input");
        }
    }
}