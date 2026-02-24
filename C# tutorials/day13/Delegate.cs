using System;

delegate void PaymentDelegate(decimal amount);

class PaymentService
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine("Payment of " + amount + " processed successfully.");
    }
}

static class PaymentExtensions
{
    public static bool isValidPayment(this decimal amount)
    {
        return amount > 0 && amount < 1000000;
    }
}


delegate void OrderDelegate(string orderId);

class NotificationService
{
    public void SendEmail(string id)
    {
        Console.WriteLine("Email sent for order: " + id);
    }

    public void SendSMS(string id)
    {
        Console.WriteLine("SMS sent for order: " + id);
    }
}


class Button
{
    public delegate void ClickHandler();
    public event ClickHandler Clicked;
    public void Click()
    {
        if (Clicked != null)
        {
            Clicked?.Invoke();
        }
    }
}