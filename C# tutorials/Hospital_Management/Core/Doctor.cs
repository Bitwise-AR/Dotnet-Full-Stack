public class Doctor
{
    public static int TotalDoctors;
    public readonly string LicenseNumber;
    public required string Name { get; set; }

    static Doctor()
    {
        TotalDoctors = 0;
    }

    public Doctor(string licenseNumber)
    {
        LicenseNumber = licenseNumber;
        TotalDoctors++;
    }
}

public class Cardiologist : Doctor
{
    public Cardiologist(string licenseNumber) : base(licenseNumber)
    {
        Console.WriteLine("Total Doctors: " + TotalDoctors);
        Console.WriteLine("License Number: " + LicenseNumber);
    }
    public void PrintName()
    {
        Console.WriteLine("Name: " + Name);
    }
    public void PrintLicenseNumber()
    {
        Console.WriteLine("License Number: " + LicenseNumber);
    }
}