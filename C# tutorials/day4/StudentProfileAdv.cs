// EXTENDED TASK: Advanced Properties in C#
// Task Title

// Student Profile System – Advanced Property Types

// Objective

// To understand and implement:

// Normal properties with validation

// Auto-implemented properties

// Read-only properties

// Write-only properties

// Base Scenario

// You are developing a Student Profile System for a college application.

// Each student has:

// Name

// Age

// Marks

// Student ID

// Password

// Different data requires different access rules.

// PART A: Auto-Implemented Property
// Requirement

// Store the Student ID.

// Rules:

// No validation required

// Direct get and set allowed

// Task Instruction

// Use an auto-implemented property.

// Hint

// Auto-implemented properties do not require a private backing field.

// PART B: Read-Only Property
// Requirement

// Calculate Result Status based on marks.

// Rules:

// Marks ≥ 40 → “Pass”

// Marks < 40 → “Fail”

// Value should be readable

// Value should NOT be set from outside

// Task Instruction

// Create a read-only property.

// PART C: Write-Only Property
// Requirement

// Store Password securely.

// Rules:

// Password can be set

// Password must NOT be readable

// Password length must be at least 6 characters

// Task Instruction

// Create a write-only property.

// PART D: Normal Property with Validation (Revision)
// Requirement

// Name cannot be empty

// Age must be greater than 0

// Marks must be between 0 and 100

// PART 5: Property with Private Set
// Requirement
// Store the Registration Number.
// Rules
// Value should be readable from outside


// Value should be modifiable only inside the class


// Task Instruction
// Use a property with public get and private set


// Assign the value internally (constructor or method)



// PART 6: Init-Only Property
// Requirement
// Store the Admission Year.
// Rules
// Value should be set only at the time of object creation


// Value must not be modified later


// Task Instruction
// Use an init-only property


// Set the value using object initializer syntax



// PART 7: Expression-Bodied Property
// Requirement
// Create a property to calculate Percentage.
// Rules
// Percentage = (Marks / 100) × 100


// Property should be read-only


// Use shortest possible syntax


// Task Instruction
// Implement an expression-bodied property



// PART 8: Usage Task
// In the Main() method:
// Create a Student object


// Assign values using all allowed properties


// Display all readable properties


// Try accessing restricted properties and note compiler errors

class Student
{
    // Normal private fields
    private string name;
    private int age;
    private int marks;
    private string password;

    // PART A: Auto-Implemented Property
    public int StudentId { get; set; }

    // PART D: Normal Property - Name
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                name = value;
            }
        }
    }

    // PART D: Normal Property - Age
    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            if (value > 0)
            {
                age = value;
            }
        }
    }

    // PART D: Normal Property - Marks
    public int Marks
    {
        get
        {
            return marks;
        }
        set
        {
            if (value >= 0 && value <= 100)
            {
                marks = value;
            }
        }
    }

    // PART B: Read-Only Property
    public string Result
    {
        get
        {
            return marks >= 40 ? "Pass" : "Fail";
        }
    }

    // PART C: Write-Only Property
    public string Password
    {
        set
        {
            if (value.Length >= 6)
            {
                password = value;
            }
        }
    }

    // ==============================
    // PART 5: Property with Private Set
    // ==============================

    public int RegistrationNumber { get; private set; }

    // =========================
    // PART 6: Init-Only Property
    // =========================

    public int AdmissionYear { get; init; }

    // =========================
    // PART 7: Expression-Bodied Property
    // =========================

    public double Percentage => (marks / 100.0) * 100;

    // Constructor (sets private-set property)
    public Student(int regNo)
    {
        RegistrationNumber = regNo;
    }

}