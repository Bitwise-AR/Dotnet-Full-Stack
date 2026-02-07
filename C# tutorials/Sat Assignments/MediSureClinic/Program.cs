﻿class Program
{
    public static PatientBill? LastBill;
    public static bool HasLastBill;

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("================== MediSure Clinic Billing ==================");
            Console.WriteLine("1. Create New Bill (Enter Patient Details)");
            Console.WriteLine("2. View Last Bill");
            Console.WriteLine("3. Clear Last Bill");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid option. Please try again.");
                continue;
            }
            switch (choice)
            {
                case 1:
                    LastBill = new PatientBill(); 
                    Console.Write("Enter Bill Id: ");
                    string? input;
                    input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Bill Id cannot be empty.");
                        break;
                    }
                    LastBill.BillId = input; 
                    Console.Write("Enter Patient Name: ");
                    input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Name cannot be empty.");
                        break;
                    }
                    LastBill.PatientName = input;
                    Console.Write("Is the patient insured? (Y/N): ");
                    input = Console.ReadLine();
                    string ins = string.IsNullOrEmpty(input) ? "" : input.ToUpper();
                    if (ins != "Y" && ins != "N")
                    {
                        Console.WriteLine("Invalid input for insurance.");
                        break;
                    }
                    LastBill.HasInsurance = ins == "Y";
                    Console.Write("Enter Consultation Fee: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal consultationFee) || consultationFee <= 0)
                    {
                        Console.WriteLine("Invalid consultation fee.");
                        break;
                    }
                    LastBill.ConsultationFee = consultationFee; 
                    Console.Write("Enter Lab Charges: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal labCharges) || labCharges < 0)
                    {
                        Console.WriteLine("Invalid lab charges.");
                        break;
                    }
                    LastBill.LabCharges = labCharges;
                    Console.Write("Enter Medicine Charges: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal medicineCharges) || medicineCharges < 0)
                    {
                        Console.WriteLine("Invalid medicine charges.");
                        break;
                    }
                    LastBill.MedicineCharges = medicineCharges;
                    HasLastBill = true;
                    Console.WriteLine("Bill created successfully.");
                    Console.WriteLine($"Gross Amount: {LastBill.GrossAmount():F2}");
                    Console.WriteLine($"Discount Amount: {LastBill.DiscountAmount():F2}");
                    Console.WriteLine($"Final Payable: {LastBill.FinalPayable():F2}");
                    Console.WriteLine("------------------------------------------------------------");
                    break;
                case 2:
                    if (!HasLastBill)
                    {
                        Console.WriteLine("No bill available. Please create a new bill first.");
                    }
                    else
                    {
                        Console.WriteLine("----------- Last Bill -----------");
                        Console.WriteLine($"BillId: {LastBill?.BillId}");
                        Console.WriteLine($"Patient: {LastBill?.PatientName}");
                        Console.WriteLine($"Insured: {(LastBill?.HasInsurance == true ? "Yes" : "No")}");
                        Console.WriteLine($"Consultation Fee: {LastBill?.ConsultationFee:F2}");
                        Console.WriteLine($"Lab Charges: {LastBill?.LabCharges:F2}");
                        Console.WriteLine($"Medicine Charges: {LastBill?.MedicineCharges:F2}");
                        Console.WriteLine($"Gross Amount: {LastBill?.GrossAmount():F2}");
                        Console.WriteLine($"Discount Amount: {LastBill?.DiscountAmount():F2}");
                        Console.WriteLine($"Final Payable: {LastBill?.FinalPayable():F2}");
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("------------------------------------------------------------");
                    }
                    break;
                case 3:
                    LastBill = null;
                    HasLastBill = false;
                    Console.WriteLine("Last bill cleared.");
                    break;
                case 4:
                    Console.WriteLine("Thank you. Application closed normally.");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}