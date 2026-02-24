// // Sealed Classes and Methods
// // Sealed Class
// // Prevents inheritance.
// // Sealed classes act as the "final version" of a class, ensuring that its logic cannot be altered or extended by any other class.
// sealed class Security { }

// // Sealed Method
// // Prevents overriding.
// // A sealed method prevents further subclasses from changing the behavior of an inherited method.
// class Parent
// {
//     public virtual void Show() { }
// }

// class Child : Parent
// {
//     public sealed override void Show() { }
// }

// class Parent
// {
//     public virtual void Show()
//     {
//         Console.WriteLine("Parent Show");
//     }
// }

// class Child : Parent
// {
//     public sealed override void Show()
//     {
//         Console.WriteLine("Child Show");
//     }
// }