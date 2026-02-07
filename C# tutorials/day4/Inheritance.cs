// class Vehicle
// {
//     public void Start()
//     {
//         Console.WriteLine("Vehicle started");
//     }
// }

// class Car : Vehicle
// {
//     public void Start()
//     {
//         Console.WriteLine("Car started");
//     }

//     public void Drive()
//     {
//         Console.WriteLine("Car is driving");
//     }
// }


// class Person
// {
//     public string Name;

//     public Person(string name)
//     {
//         Name = name;
//     }
// }

// class Students : Person
// {
//     public int RollNo;

//     public Students(string name, int roll) : base(name)
//     {
//         RollNo = roll;
//     }
// }

// // Single Inheritance
// // One base class, one derived class.
// class Animal
// {
//     public void Eat()
//     {
//         Console.WriteLine("Animal eats");
//     }
// }

// class Dog : Animal
// {
//     public void Bark()
//     {
//         Console.WriteLine("Dog barks");
//     }
// }

// // Multilevel Inheritance
// // A class is derived from another derived class.
// class LivingBeing
// {
//     public void Breathe()
//     {
//         Console.WriteLine("Breathing");
//     }
// }

// class Human : LivingBeing
// {
//     public void Think()
//     {
//         Console.WriteLine("Thinking");
//     }
// }

// class Pilot : Human
// {
//     public void Work()
//     {
//         Console.WriteLine("Flying");
//     }
// }