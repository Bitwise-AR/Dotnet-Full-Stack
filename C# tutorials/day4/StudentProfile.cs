// // Problem Statement

// // You are designing a Student Profile System.

// // Each student has:

// // Name

// // Age

// // Marks

// // Rules (Business Logic)

// // Name cannot be empty

// // Age must be greater than 0

// // Marks must be between 0 and 100

// // You must:

// // Store data using private variables

// // Expose data using public properties

// // Apply validation inside set

// // Task Requirements
// // Step 1: Create a class Student

// // The class should contain:

// // Private fields:

// // name

// // age

// // marks

// // Step 2: Create Properties

// // Create the following properties:

// // 1. Name Property

// // get → returns name

// // set → assigns name only if it is not empty

// // 2. Age Property

// // get → returns age

// // set → allows age only if greater than 0

// // 3. Marks Property

// // get → returns marks

// // set → allows marks only between 0 and 100

// // Step 3: Use the Properties

// // In Main():

// // Create a student object

// // Assign values using properties


// class Student
// {
//     // Private fields (data hiding)
//     private string name;
//     private int age;
//     private int marks;

//     // Property for Name
//     public string Name
//     {
//         get
//         {
//             return name;
//         }
//         set
//         {
//             if (!string.IsNullOrEmpty(value))
//             {
//                 name = value;
//             }
//         }
//     }

//     // Property for Age
//     public int Age
//     {
//         get
//         {
//             return age;
//         }
//         set
//         {
//             if (value > 0)
//             {
//                 age = value;
//             }
//         }
//     }

//     // Property for Marks
//     public int Marks
//     {
//         get
//         {
//             return marks;
//         }
//         set
//         {
//             if (value >= 0 && value <= 100)
//             {
//                 marks = value;
//             }
//         }
//     }
// }
