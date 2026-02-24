// // Method Overriding
// // A derived class can modify the behavior of a base class method.
// // Base Class
// class Animal
// {
//     public virtual void Sound()
//     {
//         Console.WriteLine("Animal makes sound");
//     }
// }

// // Derived Class

// class Dog : Animal
// {
//     public override void Sound()
//     {
//         base.Sound();
//         Console.WriteLine("Dog barks");
//     }
// }