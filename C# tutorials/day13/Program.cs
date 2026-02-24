// using System.Text;
// using SmartHomeSecurity;
// using CallbackDemo;
// using System.Security.Cryptography.X509Certificates;
// class Program
// {
//     public static void Main(string[] args)
//     {
//         // PaymentService service = new PaymentService();
//         // PaymentDelegate payment = service.ProcessPayment;
//         // payment(5000);

//         // NotificationService service = new NotificationService();
//         // OrderDelegate notify = null;
//         // notify += service.SendEmail;
//         // notify += service.SendSMS;
//         // notify("ORD1001");

//         // Func<decimal, decimal, decimal> calculateDiscount = (price, discount) =>  price - (price * discount / 100);
//         // Console.WriteLine(calculateDiscount(1000, 10));

//         // Predicate<int> isEligible = age => age >= 18;
//         // Console.WriteLine(isEligible(20));

//         // Button btn = new Button();
//         // btn.Clicked += () => Console.WriteLine("Button was Clicked");
//         // btn.Click();

//         // Objects Initialization
//         MotionSensor livingRoomSensor = new MotionSensor();
//         AlarmSystem siren = new AlarmSystem();
//         PoliceNotifier police = new PoliceNotifier();

//         // 2. INSTANTIATION & MULTICASTING
//         // We "Subscribe" different methods to the sensor's delegate
//         SecurityAction panicSequence = siren.SoundSiren; // Assignment of methods
//         panicSequence += police.CallDispatch;

//         // Linking the sequence to the sensor
//         livingRoomSensor.OnEmergency = panicSequence;
//         // class_object.delegate_instance = delegate_instance_multicast

//         // Simulation
//         livingRoomSensor.DetectIntruder("Main Lobby");
//     }
// }
